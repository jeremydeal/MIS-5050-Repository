using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TaxableProduct
/// </summary>
public class TaxableProduct : Product
{
    // fields
    private decimal taxRate = 1.15M;

    // properties
    public decimal TotalPrice
    {
        get { return Price*taxRate; }
    }

    // constructor
    public TaxableProduct(string name, decimal price, string imageUrl) : base(name, price, imageUrl) { }

    // methods
    public override string GetHtml()
    {
        string htmlString;
        htmlString = "<h1>" + Name + "</h1><br>";
        htmlString += "<h3>Costs: " + TotalPrice.ToString("C") + "</h3><br>";
        htmlString += "<img src='" + ImageUrl + "' />";
        htmlString += "<hr />";
        return htmlString;
    }
}