using HobbyTracker.BusinessComponent;
using HobbyTracker.BusinessEntityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HobbyTracker
{
    public partial class Member1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }
        protected async void btnAdd_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/App_Data/HobbyTracker.xml");

            //Int32 id = Convert.ToInt32(txtId.Text);
            string Item = txtName.Text;
            string ItemCategory = txtcat.Text;
            decimal Price = Convert.ToDecimal(txtPrice.Text);
            int PersonalValue = Convert.ToInt32(txtValue.Text);
            int YearsToEstimate = Convert.ToInt32(txtYears.Text);
            decimal DepreciationRate = Convert.ToDecimal(txtDepRate.Text);

            // To get DepreciationRate using web service
            decimal depreciatedPrice = await BusinessAccess.CallPriceServiceAsync(Price, YearsToEstimate, DepreciationRate);
            var convertedPrice = BusinessAccess.ConvertCurrency(Price, "USD", "INR");

            var item = new HobbyItemModel
            {
                Name = Item,
                Category = ItemCategory,
                Price = Price,
                PersonalValue = PersonalValue,
                YearsToEstimate = YearsToEstimate,
                DepreciationRate = DepreciationRate,
                DepreciatedPrice = depreciatedPrice,
                User = Session["UserName"].ToString(),
                ConvertedPrice = convertedPrice
            };
            BusinessAccess.AddOrUpdateItem(filePath, item);
            lblmsg.Text = "Record Saved Successfully";
            clearControls();


        }
        private void clearControls()
        {
            txtName.Text = "";
            txtcat.Text = "";
            txtPrice.Text = "";
            txtValue.Text = "";
            txtYears.Text = "";
            txtDepRate.Text = "";

        }
    }
}