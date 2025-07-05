using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HobbyTracker
{
    /// <summary>
    /// Summary description for HobbyTrackerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HobbyTrackerService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public decimal CalculateDepreciatedPrice(decimal originalPrice, int years, decimal annualDepreciationRate)
        {
            decimal rate = annualDepreciationRate / 100;
            decimal depreciated = originalPrice * (decimal)Math.Pow((double)(1 - rate), years);
            return Math.Round(depreciated, 2);
        }
    }
}
