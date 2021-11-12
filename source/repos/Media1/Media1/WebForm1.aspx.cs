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
            SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string path = Server.MapPath("Images/");
            if (FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName);
                if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif" || ext == ".jpeg")
                {
                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                    string name = "Images/" + FileUpload1.FileName;
                    string ss = "insert into blogs( blog_head, blog_description, blog_image) values('" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + name + "')";
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


            //byte[] bytes = null;
            //HttpPostedFile postedfile = FileUpload1.PostedFile;
            //string filename = Path.GetFileName(postedfile.FileName);
            //string fileextension = Path.GetExtension(postedfile.FileName);
            //int filesize = postedfile.ContentLength;

            //if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".bmp" || fileextension.ToLower() == ".gif" || fileextension.ToLower() == ".png")
            //{
            //    Stream stream = postedfile.InputStream;
            //    BinaryReader binaryreader = new BinaryReader(stream);
            //    bytes = binaryreader.ReadBytes((int)stream.Length);
            //}
            //else
            //{
            //    Label6.Text = "Could not load image";
            //}

            //string connectionstring = "Data Source = photogram.database.windows.net; Initial Catalog = UsersDB; User ID = PhotoGram; Password = !cmpg321; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //using (SqlConnection con = new SqlConnection(connectionstring))
            //{
            //    string query = "insert into imagedata values (@id,@filename,@fileextension,@filesize,@filecontent)";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
            //    cmd.Parameters.AddWithValue("@filename", filename);
            //    cmd.Parameters.AddWithValue("@fileextension", fileextension);
            //    cmd.Parameters.AddWithValue("@filesize", filesize);
            //    cmd.Parameters.AddWithValue("@filecontent", bytes);
            //    con.Open();
            //    cmd.ExecuteNonQuery();

            //}
        }

        protected void GetPhotoBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Blogs", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(TextBox1.Text != "")
            {
                int numphoto = Convert.ToInt32(TextBox1.Text);

                Label6.Text = dt.Rows[numphoto]["Blog_head"].ToString();
                Label7.Text = dt.Rows[numphoto]["Blog_description"].ToString();
                lblID.Text = dt.Rows[numphoto]["Id"].ToString();
                Image1.ImageUrl = dt.Rows[numphoto]["Blog_image"].ToString();
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
    }
}