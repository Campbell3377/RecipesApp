using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLibrary;

namespace RecipesApp
{
    public partial class CreateUser : System.Web.UI.UserControl
    {
        ImageVerifyService.ServiceClient imgService = new ImageVerifyService.ServiceClient("BasicHttpsBinding_IService");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Image1.Visible)
            {
                string strLength = "5";

                string myStr = imgService.GetVerifierString(strLength);
                Session["generatedString"] = myStr;

                Image1.ImageUrl = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + myStr;
                Image1.Visible = true;
            }
            //ImageVerifyService.ServiceClient imgService = new ImageVerifyService.ServiceClient("BasicHttpsBinding_IService");
            
            //imgService.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = textboxUser.Text;
            string password = textboxPass.Text;
            string verify = textboxVerify.Text;
            string captcha = (string)Session["generatedString"];

            if (verify == captcha)
            {
                Hash hash = new Hash();

                if (hash.CreateUser(user, password))  //Check user credentials
                {
                    createResult.InnerText = "Success!";
                }
                else createResult.InnerText = "Username Taken.";
            }
            else createResult.InnerText = "Captcha Failed, please try again.";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            string strLength = "5";

            string myStr = imgService.GetVerifierString(strLength);
            Session["generatedString"] = myStr;

            Image1.ImageUrl = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + myStr;
            Image1.Visible = true;
            //imgService.Close();
        }
    }
}