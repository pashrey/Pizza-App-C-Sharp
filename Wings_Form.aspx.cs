using Shrey_Final_Exam.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shrey_Final_Exam
{
    public partial class Wings_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var u_order = (order)Session["u_order"];
                if (u_order != null)
                {
                    TextBox1.Text = u_order.Wing_Price.ToString();
                    // B_S_Price. - breadstick price
                    TextBox2.Text = u_order.B_S_Price.ToString();

                }
                else
                {
                    TextBox1.Text = "0";
                    TextBox2.Text = "0";
                }
            }
        }
        private void getorder()
        {
            order u_order = Session["u_order"] as order;
            if (u_order == null)
            {
                u_order = new order();
            }
            u_order.Wing_Price = decimal.Parse(TextBox1.Text);
            u_order.B_S_Price = decimal.Parse(TextBox2.Text);
            Session["u_order"] = u_order;
        }
        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            getorder();
            Response.Redirect("Checkout_Form.aspx");
        }

        protected void orderMoreBtn_Click(object sender, EventArgs e)
        {
            getorder();
            Response.Redirect("ShreyPizza_Form.aspx");
        }
    }
}