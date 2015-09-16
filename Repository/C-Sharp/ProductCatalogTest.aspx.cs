using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // write priciest product to screen AS a TaxableProduct
        TaxableProduct priceyProduct = catalog.GetHighPricedProduct() as TaxableProduct;

        if (priceyProduct != null)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(
                "<p>{0} is the most expensive product at {1:C} (including tax), {2:C} (excluding tax).</p>",
                priceyProduct.Name, priceyProduct.TotalPrice, priceyProduct.Price);
            Response.Write(builder.ToString());
        }
    }
}