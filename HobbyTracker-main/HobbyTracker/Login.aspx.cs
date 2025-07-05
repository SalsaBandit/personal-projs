using HobbyTracker.BusinessComponent;
using HobbyTracker.SecurityComponent;
using System;
using System.Web;

namespace HobbyTracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["UserLogin"];
                if (userCookie != null)
                {
                    UserName.Text = userCookie["Username"];
                    //Password.Text = CryptoHelper.Decrypt(userCookie["Password"]);
                    Password.Attributes["value"] = CryptoHelper.Decrypt(userCookie["Password"]);
                    // NEVER prefill password from cookie in real apps for security
                    RememberMe.Checked = true;
                }
            }
        }
        protected void SubmitButton_SubmitClicked(object sender, EventArgs e)
        {
            string staffUserPath = Server.MapPath("~/App_Data/staff_users.xml");
            string userPath = Server.MapPath("~/App_Data/Users.xml");


            string userType = UserType.Text;
            if (userType == "Member")
            {

                if (BusinessAccess.IsValidUser(userPath, UserName.Text, Password.Text))
                {
                    if (RememberMe.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("UserLogin");
                        cookie["Username"] = UserName.Text;
                        cookie["Password"] = CryptoHelper.Encrypt(Password.Text);
                        cookie.Expires = DateTime.Now.AddDays(7); // valid for 7 days
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        if (Request.Cookies["UserLogin"] != null)
                        {
                            HttpCookie cookie = new HttpCookie("UserLogin");
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(cookie);
                        }
                    }

                    Session["Username"] = UserName.Text;
                    Response.Redirect("~/ViewCatalogue.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }

            }
            else
            {
                var user = BusinessAccess.ValidateStaffUser(staffUserPath, UserName.Text, Password.Text);
                if (user != null)
                {

                    Session["StaffUsername"] = user.Username;
                    Session["Access"] = user.Access;

                    Response.Redirect(user.Access == "Staff1" ? "~/Admin.aspx" : "~/SuperAdmin.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }

            }

        }
    }
}