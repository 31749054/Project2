using System;
using System.Collections.Generic;
using System.Data;
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
                //SqlConnection _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Tag = @a1, Captured_by =@a2 WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a1", TextBox2.Text);
                _cmd.Parameters.Add("a2", TextBox3.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


               // GridView1.DataBind();
                Label4.Text = "Table Updated Successfully";
            }
           



            if (TextBox1.Text != "" && TextBox2.Text == "" && TextBox3.Text != "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //SqlConnection _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Captuerd_by =@a2 WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a2", TextBox3.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


                //GridView1.DataBind();
                Label4.Text = "Table Updated Successfully";
            }
          




            if (TextBox1.Text != ""  && TextBox2.Text != "" && TextBox3.Text == "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Tagt = @a1 WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a1", TextBox2.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


             //   GridView1.DataBind();
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

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (TextBox1.Text != "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //SqlConnection _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Register_Form", _con);
                DataSet ds = new DataSet();

                


            

                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;

                if (i > Convert.ToInt32(TextBox1.Text))
                {
                   _cmd = new SqlCommand("DELETE from Blogs WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();
                   // GridView1.DataBind();
                    Label4.Text = "Data deleted Successfully";
                }
                else
                {
                    Label4.Text = "Id does not exist in the table.";
                }




            }
            else
            {
                Label4.Text = "Please enter a valid Id that exists in table.";
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            //String orderNo = Request.QueryString["ID"].ToString();
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "SELECT OrderNo, PaymentImage FROM Orders WHERE OrderNo=@OrderNo";
            //cmd.Parameters.AddWithValue("@OrderNo", Request.QueryString["ID"].ToString());
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Guid id = (Guid)(dr["PaymentImage"]);
            //    Response.TransmitFile(Server.MapPath("~/img/payments/" + id + ".jpg"));
            //}
            //con.Close();
        }
    }
}