using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace PizzaStore_WebApp
{
    public partial class PizzaOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                string conString = ConfigurationManager.ConnectionStrings["PizzaStoreDB"].ConnectionString;
                SqlConnection conn = new SqlConnection(conString);
                load_PizzaName(conn);
                load_PizzaSize(conn);
                load_PizzaToppings(conn);

            }
        }

        private void load_PizzaToppings(SqlConnection conn)
        {
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from Toppings";
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["name"].ToString();
                            item.Value = sdr["id"].ToString();
                            //item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                            chkToppings.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void load_PizzaName(SqlConnection conn)
        {

            //conn.Open();
            //SqlCommand comm = new SqlCommand("Select * from Pizzas;");
            //comm.Connection = conn;
            //SqlDataReader dr = comm.ExecuteReader();
            //dd_PizzaName.DataSource = dr;
            //dd_PizzaName.DataBind();
            //dd_PizzaName.DataTextField = "Name";
            //dd_PizzaName.DataValueField = "Id";
            //dd_PizzaName.DataBind();
            //dr.Close();
            //conn.Close();
            SqlCommand comm = new SqlCommand("Select * from Pizzas;", conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dd_PizzaName.DataSource = dt;
            dd_PizzaName.DataBind();
            dd_PizzaName.DataTextField = "Name";
            dd_PizzaName.DataValueField = "Id";
            dd_PizzaName.DataBind();
            dd_PizzaName.Items.Insert(0, new ListItem("Please Select", "NA"));

        }
        private void load_PizzaSize(SqlConnection conn)
        {
            SqlCommand comm = new SqlCommand("Select * from Sizes;", conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dd_PizzaSize.DataSource = dt;
            dd_PizzaSize.DataBind();
            dd_PizzaSize.DataTextField = "Name";
            dd_PizzaSize.DataValueField = "Id";
            dd_PizzaSize.DataBind();
            dd_PizzaSize.Items.Insert(0, new ListItem("Please Select", "NA"));

        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["PizzaStoreDB"].ConnectionString;
            using(SqlConnection con = new SqlConnection(conString))
            {
                using(SqlDataAdapter da = new SqlDataAdapter("SELECT * from Users", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Users";
                    gvPizzaRecord.DataSource = dt;
                    gvPizzaRecord.DataBind();
                }
            }
        }
    }
}