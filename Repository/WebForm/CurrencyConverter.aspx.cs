using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebForm_CurrencyConverter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Currency.Items.Add(new ListItem("Euros", "0.85"));
            Currency.Items.Add(new ListItem("Japanese Yen", "110.33"));
            Currency.Items.Add(new ListItem("Canadian Dollars", "1.2"));

            Graph.Visible = false;
        }
    }

    #region Currency Converter Events
    protected void Convert_OnServerClick(object sender, EventArgs e)
    {
        decimal dollars;
        bool success = decimal.TryParse(US.Value, out dollars);

        if (success && dollars > 0)
        {
            ResetOutputStyle();

            ListItem conversionRate = Currency.Items[Currency.SelectedIndex];

            decimal converted = dollars*decimal.Parse(conversionRate.Value);
            Result.InnerText = dollars + " U.S. dollars = ";
            Result.InnerText += converted + " " + conversionRate.Text;
        }
        else
            PrintError("Error: please enter a positive number.");
    }

    protected void ShowGraph_OnServerClick(object sender, EventArgs e)
    {
        Graph.Src = "Pic" + Currency.SelectedIndex + ".png";
        Graph.Visible = true;
    }
    #endregion

    #region Link Events
    protected void transfer_OnServerClick(object sender, EventArgs e)
    {
        Server.Transfer("SecondPage.aspx");     // doesn't change URL... cool!
    }

    protected void redirect_OnServerClick(object sender, EventArgs e)
    {
        Response.Redirect("SecondPage.aspx");
    }
    #endregion

    #region Helper Methods
    private void ResetOutputStyle()
    {
        Result.Style["color"] = "black";
    }

    private void PrintError(string error)
    {
        Result.Style["color"] = "red";
        Result.InnerText = error;
    }
    #endregion
}