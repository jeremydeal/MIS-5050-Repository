using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class C_Sharp_ProductCatalogTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // populate a new catalog
        var catalog = new ProductCatalog();
        catalog.AddProduct("Nukulizer 1945", 39.99M, "microwave.jpg");
        catalog.AddProduct("Sir Mix-a-Lot", 599.99M, "mixer.jpg");
        catalog.AddProduct("The Cylon", 1.99M, "toaster.jpg");

        // write catalog to screen
        Response.Write(catalog.GetCatalogHtml());

        // write priciest product to screen
        TaxableProduct priceyProduct = catalog.GetHighPricedProduct() as TaxableProduct;

        Response.Write("<p>" + priceyProduct.Name + " is the most expensive product at "
            + priceyProduct.TotalPrice.ToString("C") + " (including tax), "
            + priceyProduct.Price.ToString("C") +" (excluding tax).</p>");
    }
}