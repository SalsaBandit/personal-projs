using HobbyTracker.BusinessComponent;
using HobbyTracker.SecurityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HobbyTracker
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnConvert_Click(object sender, EventArgs e)
        {
            decimal amount = Convert.ToDecimal(txtAmount.Text);
            string from = txtFrom.Text.ToUpper();
            string to = txtTo.Text.ToUpper();

            var convertedPrice = BusinessAccess.ConvertCurrency(amount, from, to);
            lblResult.Text = $"Converted: {convertedPrice} {to}";

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = txtPassword.Text;
            string encrypted = CryptoHelper.Encrypt(input);
            lblEncrypted.Text = $"Encrypted: {encrypted}";

        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            string input = txtPassword.Text;
            string decrypted = CryptoHelper.Decrypt(input);
            lblEncrypted.Text = $"Decrypted: {decrypted}";

        }

        protected async void btnDepreciate_Click(object sender, EventArgs e)
        {
            decimal price = Convert.ToDecimal(txtOriginalPrice.Text);
            int years = int.Parse(txtYears.Text);
            decimal rate = decimal.Parse(txtRate.Text);

            decimal depreciated = await BusinessAccess.CallPriceServiceAsync(price, years, rate);
            lblDepreciated.Text = $"Depreciated Price: ₹{depreciated:N2}";
        }
    }
}