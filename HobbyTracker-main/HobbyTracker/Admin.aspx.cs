using HobbyTracker.BusinessComponent;
using System;
using System.Linq;

namespace HobbyTracker
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffUserName"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadDashboard();
            }
        }
        private void LoadDashboard()
        {
            string userPath = Server.MapPath("~/App_Data/Users.xml");
            string hobbyPath = Server.MapPath("~/App_Data/HobbyTracker.xml");

            // Load users
            var users = BusinessAccess.LoadUsers(userPath);


            // Load hobbies
            var hobbies = BusinessAccess.LoadHoppies(hobbyPath);

            // Count users and hobby items
            lblTotalUsers.Text = users.Count.ToString();
            lblTotalHobbyItems.Text = hobbies.Count.ToString();

            // Find most active user (based on number of items)
            var mostActiveUser = BusinessAccess.GetMostActiveUserInfo(hobbyPath);

            lblMostActiveUser.Text = $"{mostActiveUser.UserName} ({mostActiveUser.ItemCount} items)";

        }
    }
}