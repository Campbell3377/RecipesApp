using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace RecipesApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            //Get the exception object
            Exception exception = Server.GetLastError();

            //Log the error
            Console.WriteLine($"Error: {exception.Message}");

            //Clear the error
            Server.ClearError();

            //Redirect to a custom error page
            Response.Redirect("~/Error.aspx");
        }
    }
}