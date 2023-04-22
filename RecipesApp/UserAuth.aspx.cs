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
    public partial class UserAuth : System.Web.UI.Page
    {
        protected void Back_Click(object sender, EventArgs e)
        {
            //Response.Redirect("http://webstrar192.fulton.asu.edu/index.html");    
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["loginCookie"];
            if ((myCookies == null) || (myCookies["username"] == null))
            {
                //CookieLabel.InnerText = "Welcome, new user";
            }
            else
            {
                //CookieLabel.InnerText = "Welcome " + myCookies["username"];
                userVerify.Text = myCookies["username"];
                passwordVerify.Text = myCookies["password"];
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            //UserAuthWeb.Service2Client userAuth = new UserAuthWeb.Service2Client();

            //string user = userName.Text;
            //string email = emailText.Text;
            //string pass = password.Text;
            //string pass2 = password2.Text;


            //string result = userAuth.RegisterUser(user, email, pass, pass2);
            //Hash hash = new Hash();
            //hash.CreateUser(user, pass);

            //createUserResult.InnerText = result;

            //userAuth.Close();
        }

        protected void Login_Click(Object sender, EventArgs e)
        {
            //UserAuthWeb.Service2Client userAuth = new UserAuthWeb.Service2Client();
            //UserAuth.Service2Client userAuth = new UserAuth.Service2Client();
            string user = userVerify.Text;
            string password = passwordVerify.Text;

            //bool result = userAuth.Login(user, password);
            Hash hash = new Hash();
            bool result = hash.AuthenticateUser(user, password);

            if (result)
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

                loginResult.InnerText = "Result: Success!";

                //FormsAuthentication.RedirectFromLoginPage(user, false);
            }
            else loginResult.InnerText = "Incorrect Login Information.";
        }

        protected void Go_Click(Object sender, EventArgs e)
        {
            Response.Redirect("~/Protected/Member.aspx");
        }

        protected void CheckHash_Click(object sender, EventArgs e)
        {
            string user = TextBoxCheckUser.Text;
            Hash hash = new Hash();

            hashLabel.InnerText = "Result: " + hash.GetPassword(user);
        }
    }
}