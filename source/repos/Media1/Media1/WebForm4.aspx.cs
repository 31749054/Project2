using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Media1
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        string connectionstring = "Data Source=photogram.database.windows.net;Initial Catalog=UsersDB;User ID=PhotoGram;Password=!cmpg321;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || txtUserID.Text == "" || TextBox6.Text == "" || TextBox7.Text == "" || TextBox8.Text == "" || TextBox1.Text == "" || TextBox2.Text == "")
            {
                Label10.Text = "Pleas fill in all fields.";
            }
            else if (TextBox4.Text != TextBox5.Text)
            {
                Label10.Text = "Password does not match!";
            }
            else
            {



                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                //    SqlCommand cmd = new SqlCommand("UserAddOrEdit", con);


                    string ss = "insert into Register_Form(User_id, First_Name, Last_Name, User_Name, Password, Confirm_Password, Gender, Address, Email_id) values('" + txtUserID.Text + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "' , '" + TextBox5.Text + "' , '" + TextBox6.Text + "' , '" + TextBox7.Text + "' , '" + TextBox8.Text + "')";
                    SqlCommand cmd = new SqlCommand(ss, con);

                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@User_id", Convert.ToInt32(hfUserID.Value == "" ? "2" : hfUserID.Value));
                    //cmd.Parameters.AddWithValue("@First_Name", TextBox1.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Last_Name", TextBox2.Text.Trim());
                    //cmd.Parameters.AddWithValue("@User_Name", TextBox3.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Password", TextBox4.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Confirm_Password", TextBox5.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Gender", TextBox6.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Address", TextBox7.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Email_id", TextBox8.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();
                  //  Convert.ToInt32(hfUserID.Value == "" ? "1" : hfUserID.Value))
                    Clear();
                    Label9.Text = "Submitted Successfully";

                }
            }
        }
        void Clear()
        {
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text = TextBox7.Text= txtUserID.Text = TextBox8.Text = "";
            hfUserID.Value = "";
            Label10.Text = Label9.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
    }
}