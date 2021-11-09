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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            byte[] bytes = null;


            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileextension = Path.GetExtension(postedFile.FileName);
            int filesize = postedFile.ContentLength;

            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".bmp" ||
                fileextension.ToLower() == ".gif" || fileextension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                bytes = binaryreader.ReadBytes((int)stream.Length);
            
            

            }
            else
            {
                //else code for not image type here
            }

            //now code for database
            string connectionstring = "Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = "insert into imagedata values (@id,@filename,@fileextension,@filesize,@filecontent)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txtid.Text.Trim());
                cmd.Parameters.AddWithValue("@fielname", filename);
                cmd.Parameters.AddWithValue("@fileextension", fileextension);
                cmd.Parameters.AddWithValue("@filesize", filesize);
                cmd.Parameters.AddWithValue("@filecontent", bytes);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void showbtn_Click(object sender, EventArgs e)
        {

            string connectionstring = "Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = "select * from imagedata where id ='" + txtid.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    byte[] bytes = (byte[])dt.Rows[0]["filecontent"];
                    string str = Convert.ToBase64String(bytes);

                    Image1.ImageUrl = "data:Image/png;base64," + str;
                }
            }

        }

    }
}