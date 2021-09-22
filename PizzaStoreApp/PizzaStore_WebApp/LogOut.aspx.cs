using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PizzaStore_WebApp
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to Log out", "Sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Session.Clear();
                Response.Redirect("Default.aspx");
            }
            else if (dialogResult == DialogResult.No)
            {
                Response.Redirect("Default.aspx");
            }
          
        }
    }
}