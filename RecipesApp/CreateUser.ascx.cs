using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

namespace RecipesApp
{
    public partial class CreateUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = textboxUser.Text;
            string password = textboxPass.Text;

            //bool result = userAuth.Login(user, password);
            Hash hash = new Hash();

            if (hash.CreateUser(user, password))  //Check user credentials
            {
                createResult.InnerText = "Success!";
            }
            else createResult.InnerText = "Username Taken.";
        }
    }
}