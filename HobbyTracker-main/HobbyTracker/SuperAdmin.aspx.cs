using HobbyTracker.BusinessComponent;
using HobbyTracker.BusinessEntityComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HobbyTracker
{
    public partial class SuperAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffUserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            BindGrid(0);
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMinValue.Text, out decimal minValue))
            {
                BindGrid(minValue);
            }
        }
        private void BindGrid(decimal minValue = 0)
        {

            List<HobbyItemModel> items = BusinessAccess.LoadItemsAboveValue(Server.MapPath("~/App_Data/HobbyTracker.xml"), minValue);
            gvHighValueItems.DataSource = items;
            gvHighValueItems.DataBind();
        }


        protected void btnExportXml_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtMinValue.Text, out decimal minValue);
            var items = BusinessAccess.LoadItemsAboveValue(Server.MapPath("~/App_Data/HobbyTracker.xml"), minValue);

            Response.Clear();
            Response.ContentType = "application/xml";
            Response.AddHeader("content-disposition", "attachment;filename=HighValueItems.xml");

            var xDoc = new XDocument(
                new XElement("HighValueItems",
                    items.Select(i =>
                        new XElement("Hobby",
                            new XElement("Name", i.Name),
                            new XElement("Category", i.Category),
                            new XElement("Price", i.Price),
                            new XElement("User", i.User)
                        )
                    )
                )
            );

            Response.Write(xDoc.ToString());
            Response.End();
        }

        protected void btnExportCsv_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtMinValue.Text, out decimal minValue);
            var items = BusinessAccess.LoadItemsAboveValue(Server.MapPath("~/App_Data/HobbyTracker.xml"), minValue);

            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("content-disposition", "attachment;filename=HighValueItems.csv");

            using (StringWriter sw = new StringWriter())
            {
                sw.WriteLine("Name,Category,Price,User");
                foreach (var item in items)
                {
                    sw.WriteLine($"\"{item.Name}\",\"{item.Category}\",{item.Price},\"{item.User}\"");
                }
                Response.Write(sw.ToString());
            }

            Response.End();

        }
    }
}