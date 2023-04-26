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
                Response.Redirect("../LoginPage");
                return;
            }

            string staffXmlPath = Server.MapPath("~/App_Data/Staff.xml");

            //Using XML Manipulation component
            XMLManipulation staffXmlManipulation = new XMLManipulation(staffXmlPath);

            //Display the staff members to the frontend
            var staff = staffXmlManipulation.GetAllElements("staffMember");
            StaffRepeater.DataSource = staff;
            StaffRepeater.DataBind();

            string xmlFilePath = Server.MapPath("~/App_Data/members.xml");

            //Using XML Manipulation component
            XMLManipulation xmlManipulation = new XMLManipulation(xmlFilePath);

            //Display the members to the frontend
            var members = xmlManipulation.GetAllElements("member");
            MembersRepeater.DataSource = members;
            MembersRepeater.DataBind();
        }

        protected void AddStaffButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            string staffXmlPath = Server.MapPath("~/App_Data/staff.xml");

            //Using XML Manipulation component
            XMLManipulation xmlManipulation = new XMLManipulation(staffXmlPath);

            //Add the staff member to the XML file
            xmlManipulation.AddElement("staff", "staffMember", "");
            xmlManipulation.AddElement("staffMember", "username", username);
            xmlManipulation.AddElement("staffMember", "password", password);

            ResultLabel.Text = "Staff member added successfully.";
        }

        private bool IsStaffMember()
        {
            HttpCookie cookie = Request.Cookies["loginCookie"];

            //Get the logged in user
            string user = (string)Session["username"];
            string pass = (string)Session["password"];

            if (user != null && user != "")
            {

                string staffXmlPath = Server.MapPath("~/App_Data/staff.xml");

                //Using XML Manipulation component
                XMLManipulation xmlManipulation = new XMLManipulation(staffXmlPath);

                //Find staff members who fit the currently logged in user
                var staffMembers = xmlManipulation.FindElements($"//staffMember[username='{user}' and password='{pass}']");

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