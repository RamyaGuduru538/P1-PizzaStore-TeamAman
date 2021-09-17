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
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["PizzaStoreDb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("spAddNewUsers", conn);
                char gender;
                if (rbMale.Checked)
                    gender = 'M';
                else
                    gender = 'F';

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", tbName.Text);
                cmd.Parameters.AddWithValue("@Zipcode", tbZipcode.Text);
                cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                cmd.Parameters.AddWithValue("@Gender",gender);
                cmd.Parameters.AddWithValue("@Password", tbPassword.Text);
                cmd.Connection = conn;
                conn.Open();
                int record = cmd.ExecuteNonQuery();
                if (record != 0)
                {
                    MessageBox.Show("Data Inserted");
                    Response.Redirect("LoginPage.aspx");
                }
                conn.Close();
                tbName.Text = "";
                tbZipcode.Text = "";
                tbEmail.Text = "";
                tbPassword.Text = "";
                tbCPassword.Text = "";
                rbFemale.Checked = false;
                rbMale.Checked = false;
            }
        }
    }
}