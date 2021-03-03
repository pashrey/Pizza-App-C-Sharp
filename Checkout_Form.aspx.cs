using Shrey_Final_Exam.Order;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shrey_Final_Exam
{
    public partial class Checkout_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var u_order = Session["u_order"] as order;
                if (u_order != null)
                {
                    String order_text = "You place an order of:" + u_order.pizza_size_name;
                    order_text += " with " + u_order.pizza_crust_name;
                    order_text += "\nTopings:";
                    foreach (var veg_name in u_order.Non_Vtoppings)
                    {
                        order_text += veg_name + " ";
                    }
                    foreach (var veg_name in u_order.V_toppings)
                    {
                        order_text += veg_name + " ";
                    }
                    order_text += "\nSauce:" + u_order.sauce_name;
                    order_text += "\nBread Sticks:" + u_order.B_S_Price;
                    order_text += "\nChicken Wings:" + u_order.Wing_Price;
                    extraInstructionsTB.Text = order_text;
                    pizzaPriceTB.Text = u_order.P_Price.ToString();
                    decimal per_unit_nonveg = nonvegprice();
                    decimal nonveg_price = u_order.Non_Vtoppings.Count * per_unit_nonveg;
                    nonVegToppingTB.Text = nonveg_price.ToString();

                    decimal per_unit_veg = vegprice();
                    decimal veg_price = u_order.V_toppings.Count * per_unit_veg;

                    vgToppingTB.Text = veg_price.ToString();
                    breadSticktTB.Text = u_order.B_S_Price.ToString();
                    wingTB.Text = u_order.Wing_Price.ToString();
                    decimal OrderTotal = ordertotal(u_order);
                    totalTB.Text = OrderTotal.ToString();
                    decimal TotalWithTax = OrderTotal + (OrderTotal * 0.13M);
                    totalWithTaxTB.Text = TotalWithTax.ToString();

                }
            }

        }

        protected void placeOrderBtn_Click(object sender, EventArgs e)
        {
            if (Session["u_order"] != null)
            {
                var orderDetails = Session["u_order"] as order;
                var totalAmount = ordertotalwithtax(orderDetails);
                // settng range from 100-2000
                var orderNo = GetRandomNumberInRange(100, 2000);
                //populating dataset from the cache 
                DataSet1 ds;
                if (Cache["data"] != null)
                {
                    ds = (DataSet1)Cache["data"];
                }
                else
                {
                    ds = new DataSet1();
                }
                //create new row
                DataRow dr = ds.Tables["P_Order"].NewRow();
                //assig values to colummns
                dr[0] = orderNo;
                dr[1] = totalAmount;
                //add row to dataset
                ds.Tables["P_Order"].Rows.Add(dr);

                // add dataset to cache
                Cache.Insert("data", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

                // mke changes to the databse from cache
                var con = ConfigurationManager.ConnectionStrings["FinalExamConnectionString"].ConnectionString;
                SqlConnection scon = new SqlConnection(con);
                SqlCommand cmd = scon.CreateCommand();
                string insert_order = "insert into P_Order (Order_id,Order_price) values (@orderNo,@orderPrice) ";
                cmd.CommandText = insert_order;
                cmd.Parameters.AddWithValue("@orderNo", orderNo);
                cmd.Parameters.AddWithValue("@orderPrice", totalAmount);
                scon.Open();
                cmd.ExecuteNonQuery();

                Session["u_order"] = null;
                // Alert  that oder has been placed, redirecting to main-pizza page
                Response.Write("<script>alert('Your Order has been placed successfully!');window.location.href='/ShreyPizza_Form';</script>");
            }

        }
        public int GetRandomNumberInRange(int minNumber, int maxNumber)
        {
            int order_no = 0;
            int already_exist = 0;
            do
            {
                //get random order no

                /* Random r = new Random();
                   int rInt = r.Next(0, 100); //for ints
                   int range = 100;
                   double rDouble = r.NextDouble()* range; //for doubles*/

                order_no = new Random().Next(minNumber + 1, maxNumber);

                //if random order no. already exists in db then generate again new
                var connection = ConfigurationManager.ConnectionStrings["FinalExamConnectionString"].ConnectionString;
                SqlConnection scon = new SqlConnection(connection);
                SqlCommand cmd = scon.CreateCommand();
                string query = "select count(*) from  P_Order  where Order_id=@order_id ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@order_id", order_no);
                scon.Open();
                already_exist = (int)cmd.ExecuteScalar();

            } while (already_exist > 0);
            return order_no;
        }
        public decimal ordertotal(order u_order)
        {
            decimal per_unit_nonveg = nonvegprice();
            decimal per_unit_veg = vegprice();
            //Adding everything fro total price
            decimal total= u_order.P_Price  + (u_order.Non_Vtoppings.Count * per_unit_nonveg) + (u_order.V_toppings.Count * per_unit_veg) + u_order.B_S_Price + u_order.Wing_Price;
            return total; 
        }
        public decimal ordertotalwithtax(order u_order)
        {

            decimal per_unit_nonveg = nonvegprice();
            decimal per_unit_veg = vegprice();
           //  Caclulting total wid tax
            decimal total = u_order.P_Price + (u_order.Non_Vtoppings.Count * per_unit_nonveg) + (u_order.V_toppings.Count * per_unit_veg) + u_order.B_S_Price + u_order.Wing_Price;
            total = (total + (total * 0.13M));
            return total;
        }

        public decimal vegprice()
        {
            // 
            decimal price = 0;
            if(Cache["data"]!=null)
            {
               DataSet1 ds=(DataSet1) Cache["data"];
                foreach (DataRow dr in ds.Topping.Rows)
                {
                    if(dr["Top_Name"].ToString()=="Veg")
                    {
                        price = decimal.Parse(dr["Top_Price"].ToString());
                    }

                }

            }
            return price;
        }
        public decimal nonvegprice()
        {
            decimal price = 0;
            if (Cache["data"] != null)
            {
                DataSet1 ds = (DataSet1)Cache["data"];
              
                foreach (DataRow dr in ds.Topping.Rows)
                {
                    if (dr["Top_Name"].ToString() == "Non Veg")
                    {
                        price = decimal.Parse(dr["Top_Price"].ToString());
                    }

                }

            }
            return price;
        }

        protected void totalWithTaxTB_TextChanged(object sender, EventArgs e)
        {

        }
        // }
    }
}