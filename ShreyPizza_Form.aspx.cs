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
    public partial class Pizza_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if cache has no data
            if (Cache["data"] == null)
            {
                connection();
            }
            if (!IsPostBack)
            {
                // no longer connected to database;
                // reading data from cache memory

                if (Cache["data"] != null)
                {
                    DataSet1 ds = (DataSet1)Cache["data"];
                    pizzaSizeDDL.DataSource = ds.Menu;
                    pizzaSizeDDL.DataValueField = "Menu_id";
                    pizzaSizeDDL.DataTextField = "Item_Name";
                    pizzaSizeDDL.DataBind();

                    var u_order = Session["u_order"] as order;
                    if (u_order != null)
                    {
                        extraInstructionsTB.Text = u_order.E_Details;
                        pizzaSizeDDL.SelectedValue = u_order.pizza_size.ToString();
                        pizzaCrustDDL.SelectedValue = u_order.P_Crust;

                        foreach (ListItem item in vegToppingCB.Items)
                        {
                            if (u_order.V_toppings.Contains(item.Value))
                            {
                                item.Selected = true;
                            }
                        }
                        foreach (ListItem item in nonVegToppingCB.Items)
                        {
                            if (u_order.Non_Vtoppings.Contains(item.Value))
                            {
                                item.Selected = true;
                            }
                        }
                        sauceDDL.SelectedValue = u_order.sauce_name;
                    }
                }

            }

        }

        protected void pizzaOrderMoreBtn_Click(object sender, EventArgs e)
        {
            getorder();
            Response.Redirect("Wings_Form.aspx");
        }

        public void connection()
        {
            try
            {
                // create a connection , read and store data into cache

                DataSet1 ds = new DataSet1();

                String c = ConfigurationManager.ConnectionStrings["FinalExamConnectionString"].ConnectionString;
                SqlConnection scon = new SqlConnection(c);
                string query = "select * from Menu";
                SqlDataAdapter da = new SqlDataAdapter(query, scon);
                da.Fill(ds.Menu);
                //  da.Fill(ds, "Emp");

                SqlConnection scon1 = new SqlConnection(c);
                string order_query = "select * from P_Order";
                SqlDataAdapter orderAdapter = new SqlDataAdapter(order_query, scon1);
                orderAdapter.Fill(ds.P_Order);

                SqlConnection scon2 = new SqlConnection(c);
                string topping_query = "select * from Topping";
                SqlDataAdapter toppingAdapter = new SqlDataAdapter(topping_query, scon2);
                toppingAdapter.Fill(ds, "Topping");

                //to store dataset into cache, usimg keys so afterwards we can retrieve data from cache.
                //key, dataset, no dependency, for how long it should be stored, no sliding
                Cache.Insert("data", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        private void getorder()
        {
            order u_order = Session["u_order"] as order;
            if (u_order == null)
            {
                u_order = new order();
            }
            veg_check(u_order);
            nonveg_check(u_order);
            u_order.E_Details = extraInstructionsTB.Text;
            u_order.pizza_size = int.Parse(pizzaSizeDDL.SelectedItem.Value);
            u_order.P_Price = pizzasizeprice(pizzaSizeDDL.SelectedValue);
            u_order.P_Crust = pizzaCrustDDL.SelectedValue;
            u_order.pizza_crust_name = pizzaCrustDDL.SelectedItem.Text;
            u_order.pizza_size_name = pizzaSizeDDL.SelectedItem.Text;

            u_order.sauce_name = sauceDDL.SelectedValue;
            Session["u_order"] = u_order;
        }
        private void veg_check(order u_order)
        {
            u_order.V_toppings.Clear();
            foreach (ListItem item in vegToppingCB.Items)
            {
                if (item.Selected)
                {
                    u_order.V_toppings.Add(item.Value);
                }
            }
        }
        private void nonveg_check(order u_order)
        {
            u_order.Non_Vtoppings.Clear();
            foreach (ListItem item in nonVegToppingCB.Items)
            {
                if (item.Selected)
                {
                    u_order.Non_Vtoppings.Add(item.Value);
                }
            }
        }

        protected void pizzaCheckoutBtn_Click(object sender, EventArgs e)
        {
            getorder();
            Response.Redirect("Checkout_Form.aspx");
        }

        public decimal pizzasizeprice(string id)
        {
            decimal price = 0;
            if (Cache["data"] != null)
            {
                DataSet1 ds = (DataSet1)Cache["data"];
                foreach (DataRow dr in ds.Menu.Rows)
                {

                    if (dr["Menu_id"].ToString() == id.ToString())
                    {
                        price = Convert.ToDecimal(dr["Item_Price"]);
                    }
                }
            }
            return price;
        }

        protected void pizzaSizeDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void sauceDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}