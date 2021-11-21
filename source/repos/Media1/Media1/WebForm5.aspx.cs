using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
            if (Session["Username"] != null)
            {
              //  Label8.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("WebForm2.aspx");
            }

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
            GridView1.DataBind();
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //SqlConnection _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Tag = @a1, Captured_by =@a2 WHERE Id=@a3", _con);
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
                //SqlConnection _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Captured_by =@a2 WHERE Id=@a3", _con);
                _cmd.Parameters.Add("a2", TextBox3.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


                GridView1.DataBind();
                Label4.Text = "Table Updated Successfully";
            }
          




            if (TextBox1.Text != ""  && TextBox2.Text != "" && TextBox3.Text == "")
            {
                _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _con.Open();
                _cmd = new SqlCommand("UPDATE Blogs SET Tag = @a1 WHERE Id=@a3", _con);
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
                _cmd = new SqlCommand("DELETE Blogs WHERE Id=@a3", _con);
                // _cmd.Parameters.Add("a2", TextBox3.Text);
                _cmd.Parameters.Add("a3", Convert.ToInt32(TextBox1.Text));
                _cmd.ExecuteNonQuery();


                GridView1.DataBind();
                Label4.Text = "Table Updated Successfully";
            }
            else
                {
                    Label4.Text = "Please enter a valid Id that exists in table.";
                }


            //if (TextBox1.Text != "")
            //{
            //    _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //    //SqlConnection _con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //    _con.Open();
            //    SqlDataAdapter sda = new SqlDataAdapter("Select * from Blogs", _con);
            //    DataSet ds = new DataSet();


            //    sda.Fill(ds);
            //    int i = ds.Tables[0].Rows.Count;

            //    if (i > Convert.ToInt32(TextBox1.Text))
            //    {
            //        _cmd = new SqlCommand("DELETE FROM Blogs WHERE Id="+ Convert.ToInt32(TextBox1.Text)+"", _con);
            //       // _cmd.Parameters.AddWithValue("a3", Convert.ToInt32(TextBox1.Text));
            //        _cmd.ExecuteNonQuery();
            //        GridView1.DataBind();
            //        Label4.Text = "Data deleted Successfully";
            //    }

            //}
            //else
            //{
            //    Label4.Text = "Please enter a valid Id that exists in table.";
            //}
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            //string naam = "";
            //string ext = "";

            //SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "SELECT * FROM Blogs WHERE Id='" + TextBox1.Text +"'";
             
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    naam = dr.GetValue(3).ToString();
                
            //}
            //ext = System.IO.Path.GetExtension(naam);
            //MemoryStream ms = new MemoryStream();
           
            //Response.ContentType = "naam/"+ ext;
            //Response.AddHeader("Content-Disposition",string.Format( "attachment; filename={0}", naam));
            //// Response.TransmitFile(Server.MapPath("~/Files/MyFile.pdf"));
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter tw = new HtmlTextWriter(sw);
            //Response.Write(sw.ToString);
            //Response.End();

            //con.Close();
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            lblHelp.Visible = true;
            lblHelp.Text = "Please enter the fields you wish to edit or delete.";
        }
    }
}