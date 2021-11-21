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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
               // Label8.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("WebForm2.aspx");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //attempt new album


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //attempt search album

            //SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            ////SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //SqlDataAdapter sda = new SqlDataAdapter("select * from Albums ", con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //DataSet ds = new DataSet();

            //if (TextBox1.Text != "")
            //{
            //    int numphoto = Convert.ToInt32(TextBox1.Text);

            //    sda.Fill(ds);
            //    int i = ds.Tables[0].Rows.Count;

            //    if (i > Convert.ToInt32(TextBox1.Text))
            //    {
            //        Label6.Text = dt.Rows[numAlbum]["User_id"].ToString();
            //        Label7.Text = dt.Rows[numAlbum]["album_id"].ToString();
                  
            //    }
            //    else
            //    {
            //        Label1.Text = "Id does not exist in the table.";
            //    }



            //}
            //else
            //{
            //    Label1.Text = "Please Enter the ID of the Album.";
            //}
        }





        protected void Button4_Click(object sender, EventArgs e)
        {
            // add image to album

        //    SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    string path = Server.MapPath("Albums/");

        //    if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif" || ext == ".jpeg" || ext == ".ico" || ext == ".tiff")
        //    {
        //        string ss = "insert into blogs( users_id, album_id) values('" + TextBox2.Text + "', '" + TextBox3.Text + "')";
        //        SqlCommand cmd = new SqlCommand(ss, con);
        //        SqlDataAdapter sda = new SqlDataAdapter("select * from Albums", con);
        //        sda.Fill(dt);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //        Label1.Text = "Your blog has been created successfully";
        //        Label1.ForeColor = System.Drawing.Color.Green;

        //        Panel2.Visible = true;
        //    }
        //    else
        //    {

        //        Label1.Text = "You have to upload jpg or png file only!";
        //    }
        //}
        //    else
        //    {
        //        Label1.Text = "Please select file!";
        //    }
}

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm8.aspx");
        }
    }
}