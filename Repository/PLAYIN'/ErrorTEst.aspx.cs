using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PLAYIN_ErrorTEst : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmdSubmit_OnClick(object sender, EventArgs e)
    {
        try
        {
            decimal a, b, result;
            a = Decimal.Parse(txt1.Text);
            b = Decimal.Parse(txt2.Text);
            result = a / b;
            lbl1.Text = result.ToString();
            lbl1.ForeColor = Color.Black;
        }
        catch (Exception err)
        {
            lbl1.Text = "<b>Message:</b> " + err.Message +
                "<br/><br/>" +
                "<b>Source:</b> " + err.Source +
                "<br/><br/>" +
                "<b>Stack Trace:</b> " + err.StackTrace;
            lbl1.ForeColor = Color.Red;
        }
    }
}