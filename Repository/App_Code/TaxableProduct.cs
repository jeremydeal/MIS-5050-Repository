using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("<h1>{0}</h1><br>", Name);
        builder.AppendFormat("<h3>Costs: {0:C}</h3><br>", TotalPrice);
        builder.AppendFormat("<img src='{0}' />", ImageUrl);
        builder.Append("<hr />");
        return builder.ToString();
    }
}