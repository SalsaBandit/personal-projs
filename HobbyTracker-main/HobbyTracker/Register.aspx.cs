using HobbyTracker.BusinessComponent;
using HobbyTracker.BusinessEntityComponent;
using HobbyTracker.SecurityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HobbyTracker
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitButton_SubmitClicked(object sender, EventArgs e)
        {
            string userPath = Server.MapPath("~/App_Data/Users.xml");


            var item = new UserModel
            {
                UserName = UserName.Text,
                Password = CryptoHelper.Encrypt(Password.Text),

            };
            BusinessAccess.AddOrUpdateUser(userPath, item);
            ErrorMessage.Text = "Record Saved Successfully, Please log to your account.";
            UserName.Text = "";
            Password.Text = "";
            ConfirmPassword.Text = "";

        }
    }
}