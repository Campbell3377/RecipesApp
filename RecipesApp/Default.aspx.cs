using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("./LoginPage");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("./UserAuth");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Staff_Pages/Staff");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Member_Pages/Browse");
        }
    }
}