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
    public partial class ViewCatalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadAndBindGrid(Server.MapPath("~/App_Data/HobbyTracker.xml"));
            }

        }
        private void LoadAndBindGrid(string path)
        {
            var hobbies = BusinessAccess.LoadHoppiesByUser(Server.MapPath("~/App_Data/HobbyTracker.xml"), Session["UserName"].ToString());
            gvHobbies.DataSource = hobbies;
            gvHobbies.DataBind();
        }
        protected void gvHobbies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHobbies.PageIndex = e.NewPageIndex;
            LoadAndBindGrid(Server.MapPath("~/App_Data/HobbyTracker.xml"));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string currentUser = Session["UserName"].ToString();
            var hobbies = BusinessAccess.LoadHoppiesByUser(Server.MapPath("~/App_Data/HobbyTracker.xml"), currentUser);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                hobbies = hobbies.Where(x => x.Name.ToLower().Contains(searchText.ToLower()) || x.Category.ToLower().Contains(searchText.ToLower())).ToList();
            }

            gvHobbies.DataSource = hobbies.ToList();
            gvHobbies.DataBind();

        }
        protected void gvHobbies_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHobbies.EditIndex = e.NewEditIndex;
            LoadAndBindGrid(Server.MapPath("~/App_Data/HobbyTracker.xml")); // reload the grid
        }
        protected void gvHobbies_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHobbies.EditIndex = -1;
            LoadAndBindGrid(Server.MapPath("~/App_Data/HobbyTracker.xml"));
        }
        protected async void gvHobbies_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvHobbies.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvHobbies.Rows[e.RowIndex];

            var item = new HobbyItemModel
            {
                Id = id,
                Name = ((TextBox)row.Cells[0].Controls[0]).Text,
                Category = ((TextBox)row.Cells[1].Controls[0]).Text,
                Price = Convert.ToDecimal(((TextBox)row.Cells[2].Controls[0]).Text),
                PersonalValue = Convert.ToInt16(((TextBox)row.Cells[3].Controls[0]).Text),
                YearsToEstimate = Convert.ToInt16(((TextBox)row.Cells[4].Controls[0]).Text),
                DepreciationRate = Convert.ToDecimal(((TextBox)row.Cells[4].Controls[0]).Text),
                DepreciatedPrice = Convert.ToDecimal(((TextBox)row.Cells[5].Controls[0]).Text)
            };
            // To get DepreciationRate using web service
            item.DepreciatedPrice = await BusinessAccess.CallPriceServiceAsync(item.Price, item.YearsToEstimate, item.DepreciationRate);
            item.ConvertedPrice = BusinessAccess.ConvertCurrency(item.Price, "USD", "INR");

            BusinessAccess.AddOrUpdateItem(Server.MapPath("~/App_Data/HobbyTracker.xml"), item);
            gvHobbies.EditIndex = -1;
            LoadAndBindGrid(Server.MapPath("~/App_Data/HobbyTracker.xml"));
        }
        protected void gvHobbies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvHobbies.DataKeys[e.RowIndex].Value);
            BusinessAccess.DeleteHobby(Server.MapPath("~/App_Data/HobbyTracker.xml"), id);
            LoadAndBindGrid(Server.MapPath("~/App_Data/HobbyTracker.xml"));
        }
    }
}