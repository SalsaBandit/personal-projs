using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HobbyTracker
{
    public partial class SubmitButton : System.Web.UI.UserControl
    {
        public event EventHandler SubmitClicked;
        public string Title
        {
            get { return btnSubmit.Text; }
            set { btnSubmit.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Raise the event to notify the parent page
            if (SubmitClicked != null)
            {
                SubmitClicked(this, e);
            }
        }
    }
}