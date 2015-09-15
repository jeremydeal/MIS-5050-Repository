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
        // LINQified
        // decimal max = GetMaxPrice()

        // var costliestProducts =
        //    from p in products
        //    where p.Price == max
        //    select p;

        //return costliestProducts.First();

        if (products.Count > 0)
        {
            Product max = products[0];

            foreach (var p in products)
                if (p.Price > max.Price)
                    max = p;

            return max;
        }
        
        return null;
    }

    private decimal GetMaxPrice()
    {
        return products.Max(p => p.Price);
    }

    public string GetCatalogHtml()
    {
        // as LINQ expression
        // return products.Cast<Product>().Aggregate("", (current, p) => current + p.GetHtml());

        string html = "";
        foreach (Product p in products)
            html += p.GetHtml();

        return html;
    }
}