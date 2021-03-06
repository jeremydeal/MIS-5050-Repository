using System;
using System.Globalization;
using System.Text;

// Define the delegate that represents the event.
public delegate void PriceChangedEventHandler();

public class Product
{
    // private member variables
    private string name;
    private decimal price;
    private string imageUrl;

    // Define the event.
    public event PriceChangedEventHandler PriceChanged;

    // public properties
    public string Name
    {
        get
        { return name; }
        set
        {
//          if (value != null && value.StartsWith("s", true, CultureInfo.CurrentCulture))
                name = value;
        }
    }

    public decimal Price
    {
        get
        { return price; }
        set
        {
            price = value;

            // Fire the event, provided there is at least one listener.
            if (PriceChanged != null)
            {
                PriceChanged();
            }
        }
    }

    public string ImageUrl
    {
        get
        { return imageUrl; }
        set
        { imageUrl = value; }
    }

    // member methods
    public virtual string GetHtml()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("<h1>{0}</h1><br>", Name);
        builder.AppendFormat("<h3>Costs: {0:C}</h3><br>", Price);
        builder.AppendFormat("<img src='{0}' />", ImageUrl);
        builder.Append("<hr />");
        return builder.ToString();
    }

    public Product(string name, decimal price, string imageUrl)
    {
        // note: using property names instead of private member variable names in the contructor
        // ensures that the constructor does not bypass any validation / data manipulation code
        // ENCAPSULATION, bro
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
    }
}

