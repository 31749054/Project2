using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Media1
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        private SqlConnection _con;
        private SqlCommand _cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {   
            if(TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Blog_head = @a1, Blog_Description =@a2 WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a1", TextBox2.Text);
                _cmd.Parameters.Add("a2", TextBox3.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


                GridView1.DataBind();
                Label4.Text = "Table Updated Successfully";
            }
           



            if (TextBox1.Text != "" && TextBox2.Text == "" && TextBox3.Text != "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Blog_Description =@a2 WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a2", TextBox3.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


                GridView1.DataBind();
                Label4.Text = "Table Updated Successfully";
            }
          




            if (TextBox1.Text != ""  && TextBox2.Text != "" && TextBox3.Text == "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Blog_head = @a1 WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a1", TextBox2.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


                GridView1.DataBind();
                Label4.Text = "Table Updated Successfully";
            }
            else
            {
                Label4.Text = "Please enter a valid picture Id";
            }



        }

        protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }
    }
}