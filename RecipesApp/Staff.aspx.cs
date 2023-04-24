using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RecipesApp.XMLFileUtils;

namespace RecipesApp
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsStaffMember())
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            string staffXmlPath = Server.MapPath("~/App_Data/Staff.xml");
            XMLManipulation staffXmlManipulation = new XMLManipulation(staffXmlPath);
            var staff = staffXmlManipulation.GetAllElements("staffMember");
            StaffRepeater.DataSource = staff;
            StaffRepeater.DataBind();

            string xmlFilePath = Server.MapPath("~/App_Data/members.xml");
            XMLManipulation xmlManipulation = new XMLManipulation(xmlFilePath);
            var members = xmlManipulation.GetAllElements("member");
            MembersRepeater.DataSource = members;
            MembersRepeater.DataBind();
        }

        protected void AddStaffButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            string staffXmlPath = Server.MapPath("~/App_Data/staff.xml");
            XMLManipulation xmlManipulation = new XMLManipulation(staffXmlPath);

            xmlManipulation.AddElement("staff", "staffMember", "");
            xmlManipulation.AddElement("staffMember", "username", username);
            xmlManipulation.AddElement("staffMember", "password", password);

            ResultLabel.Text = "Staff member added successfully.";
        }

        private bool IsStaffMember()
        {
            HttpCookie cookie = Request.Cookies["loginCookie"];

            if (cookie != null)
            {
                string username = cookie["Username"];
                string password = cookie["Password"];

                string staffXmlPath = Server.MapPath("~/App_Data/staff.xml");
                XMLManipulation xmlManipulation = new XMLManipulation(staffXmlPath);

                var staffMembers = xmlManipulation.FindElements($"//staffMember[username='{username}' and password='{password}']");

                //Check if any matching staff members were found
                if (staffMembers.Length > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}