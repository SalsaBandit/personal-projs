using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace HobbyTracker.ServiceComponent
{
    public class ServiceAccess
    {
        public static async Task<decimal> CallPriceServiceAsync(decimal originalPrice, int years, decimal annualDepreciationRate)
        {
            using (HttpClient client = new HttpClient())
            {
                //var url = "http://localhost:81/Service/HobbyTrackerService.asmx";
                var url = "http://webstrar11.fulton.asu.edu/Page2/HobbyTrackerService.asmx";


                string soapEnvelope = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
               xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <CalculateDepreciatedPrice xmlns=""http://tempuri.org/"">
      <originalPrice>{0}</originalPrice>
      <years>{1}</years>
      <annualDepreciationRate>{2}</annualDepreciationRate>
    </CalculateDepreciatedPrice>
  </soap:Body>
</soap:Envelope>";
                soapEnvelope = string.Format(soapEnvelope, originalPrice, years, annualDepreciationRate);
                var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
                content.Headers.Add("SOAPAction", "\"http://tempuri.org/CalculateDepreciatedPrice\"");



                // Call the service
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();

                    var doc = XDocument.Parse(jsonResult);

                    // Navigate to the SOAP body
                    XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";
                    XNamespace ns = "http://tempuri.org/"; // Your actual namespace

                    var result = doc
                        .Descendants(soap + "Body")
                        .Descendants(ns + "CalculateDepreciatedPriceResponse")
                        .Descendants(ns + "CalculateDepreciatedPriceResult")
                        .FirstOrDefault()?.Value;

                    decimal price = decimal.Parse(result);

                    // ASMX returns {"d": 810.0}

                    return price;
                }
                else
                {
                    throw new Exception("Failed to call web service");
                }
            }
        }
        public static decimal ConvertCurrency(decimal amount, string from, string to)
        {
            string url = $"https://api.frankfurter.app/latest?amount={amount}&from={from}&to={to}";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                    var rates = data["rates"] as JObject;
                    decimal result = rates[to].Value<decimal>();
                    return result;
                }
            }

            return 0m;
        }

    }
}
