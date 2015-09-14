using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductCatalog
/// </summary>
public class ProductCatalog
{
    // fields
    private List<TaxableProduct> products = new List<TaxableProduct>();

    // properties

    // constructor
    public ProductCatalog() { }

    // methods
    public void AddProduct(string name, decimal price, string imageUrl)
    {
        TaxableProduct product = new TaxableProduct(name, price, imageUrl);
        products.Add(product);
    }

    public Product GetHighPricedProduct()
    {
        var costliestProducts =
            from p in products
            where p.Price == GetMaxPrice()
            select p;

        return costliestProducts.First();
    }

    private decimal GetMaxPrice()
    {
        return products.Max(
            p => p.Price);
    }

    public string GetCatalogHtml()
    {
        string html = "";
        foreach (Product p in products)
            html += p.GetHtml();

        return html;
    }
}