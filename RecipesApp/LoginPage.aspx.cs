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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie loginCookie = Request.Cookies["loginCookie"];
            if (loginCookie != null)
            {
                // If the loginCookie already exists, check to automatically login
                string user = loginCookie["username"];
                string password = loginCookie["password"];
                textboxUser.Text = user;
                textboxPass.Text = password;

                /*Hash hash = new Hash();
                bool result = hash.AuthenticateUser(user, password);

                if (hash.AuthenticateUser(user, password))  
                {

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, 
                    user,  
                    DateTime.Now,  
                    DateTime.Now.AddMinutes(30), 
                    false,  
                    ""  
                    );

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);

                    Session["username"] = user;

                    FormsAuthentication.RedirectFromLoginPage(user, false);
                }*/
            }
        }
        protected void LoginFunc(object sender, EventArgs e)
        {
            string user = textboxUser.Text;
            string password = textboxPass.Text;

            //bool result = userAuth.Login(user, password);
            Hash hash = new Hash();
            bool result = hash.AuthenticateUser(user, password);

            if (hash.AuthenticateUser(user, password))  //Check user credentials
            {
                if (CheckBoxSaveLogin.Checked)
                {
                    HttpCookie loginCookie = Request.Cookies["loginCookie"];
                    if (loginCookie != null)
                    {
                        // If the loginCookie already exists, remove it
                        Response.Cookies.Remove("loginCookie");
                    }

                    // Create a new loginCookie with updated values
                    HttpCookie myCookies = new HttpCookie("loginCookie");
                    myCookies["username"] = user;
                    myCookies["password"] = password;
                    myCookies.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(myCookies);
                }

                //loginResult.InnerText = "Success!";
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,  // version
                user,  // username
                DateTime.Now,  // issue time
                DateTime.Now.AddMinutes(30),  // expiration time
                false,  // persistent
                ""  // user data
                );

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                Response.Cookies.Add(cookie);

                Session["username"] = user;
                Session["password"] = password;

                FormsAuthentication.RedirectFromLoginPage(user, false);
            }
            //else loginResult.InnerText = "Incorrect Login Information.";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Clear authentication cookie
            FormsAuthentication.SignOut();

            // Expire authentication cookie
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(authCookie);

            Session["username"] = "";

        }
    }
}