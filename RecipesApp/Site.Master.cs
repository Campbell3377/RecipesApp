using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["username"] as string;
            if (username != null)
            {
                AccountLink.InnerText = username;
                AccountLink.HRef = "~/Member_Pages/Account";
            }
            else
            {
                AccountLink.InnerText = "Log In";
                AccountLink.HRef = "~/LoginPage";
            }
        }
    }
}