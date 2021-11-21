using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Media1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
             //   Label8.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("WebForm2.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //attempt share photos
            //HttpContext.Current.Session["IsUserRole"] = true;
            //bool IsUserRole = Convert.ToBoolean(HttpContext.Current.Session["IsUserRole"])
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //attempt share albums
            //HttpContext.Current.Session["IsUserRole"] = true;
            //bool IsUserInRole = Convert.ToBoolean(HttpContext.Current.Session["IsUserRole"])
        }
    }
}