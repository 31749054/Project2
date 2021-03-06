using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace Media1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["Username"] != null)
            {
                Label8.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("WebForm2.aspx");
            }
        

        }

       
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LoadBtn_Click1(object sender, EventArgs e)
        {
           
            
                DateTime datetime = DateTime.ParseExact(TextBox4.Text, "dd/MM/yyyy", null);
                DateTime date;
            
            

            if (DateTime.TryParse(datetime.ToString(), out date))
            {
                SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                string path = Server.MapPath("Images/");
                if (FileUpload1.HasFile)
                {
                    string ext = Path.GetExtension(FileUpload1.FileName);
                    if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif" || ext == ".jpeg" || ext == ".ico" || ext == ".tiff")
                    {
                        FileUpload1.SaveAs(path + FileUpload1.FileName);
                        string name = "Images/" + FileUpload1.FileName;
                        string ss = "insert into blogs( Tag, Captured_by, blog_image, Captured_date, Location) values('" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + name + "', '" + datetime + "', '" + TextBox5.Text + "')";
                        SqlCommand cmd = new SqlCommand(ss, con);




                        SqlDataAdapter sda = new SqlDataAdapter("select * from Blogs", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);




                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        Label1.Text = "Your blog has been created successfully";
                        Label1.ForeColor = System.Drawing.Color.Green;

                        Panel2.Visible = true;
                    }
                    else
                    {

                        Label1.Text = "You have to upload jpg or png file only!";
                    }
                }
                else
                {
                    Label1.Text = "Please select file!";
                }


                //con.Open();

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = con;
                //cmd.CommandText = "UPDATE Orders SET PaymentImage = @Image, PaymentStatus = @PaymentStatus WHERE OrderNo = @OrderNo AND PaymentStatus = 'Pending'; ";

                //string fileExt = Path.GetExtension(fuImage.FileName);
                //string id = Guid.NewGuid().ToString();

                //cmd.Parameters.AddWithValue("@OrderNo", Request.QueryString["ID"].ToString());
                //cmd.Parameters.AddWithValue("@Image", id + fileExt);
                //cmd.Parameters.AddWithValue("@PaymentStatus", "Payment Sent");

                //fuImage.SaveAs(Server.MapPath("~/img/payments/" + id + fileExt));

                //cmd.ExecuteNonQuery();
                //con.Close();

                //Response.Redirect("Default.aspx");


            }
            else
            {
                Label1.Text = "Incorrect date format.";
            }



        }

        protected void GetPhotoBtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlDataReader dr;
          
            DataSet ds = new DataSet();
           

            if (TextBox1.Text != "")
            {
                //  int numphoto = Convert.ToInt32(TextBox1.Text);
                con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Blogs WHERE Id ='" + TextBox1.Text + "'", con);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    Label6.Text = dr.GetValue(1).ToString();
                    Image1.ImageUrl = dr.GetValue(3).ToString();
                    Label7.Text = dr.GetValue(2).ToString();
                    lblID.Text = dr.GetValue(0).ToString();
                    Label13.Text = dr.GetValue(4).ToString();
                    Label16.Text = dr.GetValue(5).ToString();

                    Image1.Visible = true;
                    Label9.Visible = true;
                    Label10.Visible = true;
                    Label11.Visible = true;
                    Label17.Visible = true;
                    Label14.Visible = true;

                 
                }

                


            }
            else
            {
                Label1.Text = "Please Enter the ID of the photo.";
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("WebForm2.aspx");
        }

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm5.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm6.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm7.aspx");
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            lblIDhelp.Visible = true;
            lblAddhelp.Visible = true;
        }
    }
}