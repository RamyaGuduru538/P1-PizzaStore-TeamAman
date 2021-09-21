using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace PizzaStore_WebApp
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["PizzaStoreDb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email",tbEmail.Text );
                cmd.Parameters.AddWithValue("@Password", tbPassword.Text);
                cmd.Connection = conn;
                conn.Open();
               // MessageBox.Show(cmd.ExecuteScalar().ToString());
                int record = (int)cmd.ExecuteScalar();
                switch (record)
                {
                    case -1:
                        MessageBox.Show("Invalid email or password");
                        break;
                    default: Session["Email"] = tbEmail.Text;
                        Session["btntext"] = "Log out";
                        Response.Redirect("Default.aspx");
                        break;
                }
                conn.Close();
                tbEmail.Text = "";
                tbPassword.Text = "";
            }
        }

        protected void btn_Signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUser.aspx");
        }
    }
}