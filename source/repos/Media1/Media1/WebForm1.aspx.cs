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
            SqlDataAdapter sda = new SqlDataAdapter("select * from Blogs", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataSet ds = new DataSet();

            if(TextBox1.Text != "")
            {
                int numphoto = Convert.ToInt32(TextBox1.Text);

                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;

                if(i > Convert.ToInt32(TextBox1.Text))
                {
                    Label6.Text = dt.Rows[numphoto]["Tag"].ToString();
                    Label7.Text = dt.Rows[numphoto]["Captured_by"].ToString();
                    lblID.Text = dt.Rows[numphoto]["Id"].ToString();
                    Image1.ImageUrl = dt.Rows[numphoto]["Blog_image"].ToString();
                    Label13.Text = dt.Rows[numphoto]["Captured_date"].ToString();
                    Label16.Text = dt.Rows[numphoto]["Location"].ToString();
                }
                else
                {
                    Label1.Text = "Id does not exist in the table.";
                }

               
               
            }
            else
            {
                Label1.Text = "Please Enter the ID of the photo.";
            }




            //string connectionstring = "Data Source = photogram.database.windows.net; Initial Catalog = UsersDB; User ID = PhotoGram; Password = !cmpg321; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //using (SqlConnection con1 = new SqlConnection(connectionstring))
            //{
            //    string query = "select * from Blogs where id='" + TextBox1.Text.Trim() + "'";
            //    SqlCommand cmd = new SqlCommand(query, con1);
            //    con1.Open();
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.SelectCommand = cmd;
            //    DataTable dtbl = new DataTable();
            //    da.Fill(dtbl);
            //    if (dtbl != null && dtbl.Rows.Count > 0)
            //    {
            //        byte[] bytes = (byte[])dtbl.Rows[0]["Blog_image"];
            //        string str = Convert.ToBase64String(bytes);

            //        Image1.ImageUrl = "data:Image/png;base64," + str;
            //    }
            //    else
            //    {
            //        Label6.Text = "Could not find image";
            //    }
            //}


            Image1.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label17.Visible = true;
            Label14.Visible = true;
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
    }
}