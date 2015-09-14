using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace GreetingCardMaker
{

    public partial class GreetingCardMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // Set font options.
                lstFontName.Items.Add("Times New Roman");
                lstFontName.Items.Add("Arial");
                lstFontName.Items.Add("Verdana");
                lstFontName.Items.Add("Tahoma");

                // Set (checkbox list) picture choices.
                SortedDictionary<string, string> pictures = new SortedDictionary<string, string>();
                pictures["Happy Birthday"] = "birthday.png";
                pictures["Merry Christmas"] = "christmas.png";
                pictures["Get Well Soon"] = "get_well.gif";
                pictures["Happy Graduation"] = "graduation.jpg";
                pictures["Happy Valentine's"] = "valentine.jpg";

                foreach (KeyValuePair<string, string> entry in pictures)
                {
                    chkPicture.Items.Add(new ListItem(entry.Key, entry.Value));
                }

                // Set border style options by adding a series of
                // ListItem objects.
                ListItem item = new ListItem();

                // The item text indicates the name of the option.
                item.Text = BorderStyle.None.ToString();

                // The item value records the corresponding integer
                // from the enumeration. To obtain this value, you
                // must cast the enumeration value to an integer,
                // and then convert the number to a string so it
                // can be placed in the HTML page.
                item.Value = ((int)BorderStyle.None).ToString();

                // Add the item.
                lstBorder.Items.Add(item);

                // Now repeat the process for two other border styles.
                item = new ListItem();
                item.Text = BorderStyle.Double.ToString();
                item.Value = ((int)BorderStyle.Double).ToString();
                lstBorder.Items.Add(item);

                item = new ListItem();
                item.Text = BorderStyle.Solid.ToString();
                item.Value = ((int)BorderStyle.Solid).ToString();
                lstBorder.Items.Add(item);

                // Select the first border option.
                lstBorder.SelectedIndex = 0;

                // Set the picture.
                chkPicture.SelectedIndex = 0;
                imgDefault.ImageUrl = chkPicture.SelectedValue;
            }
        }

        protected void cmdUpdate_Click(object sender, System.EventArgs e)
        {
            UpdateCard();
        }

        protected void Control_IsChanged(object sender, EventArgs e)
        {
            UpdateCard();
        }

        private void UpdateCard()
        {
            // Update the color.
            pnlCard.BackColor = Color.FromName(lstBackColor.SelectedItem.Text);

            // Update the font.
            lblGreeting.Font.Name = lstFontName.SelectedItem.Text;

            // Update font color.
            pnlCard.ForeColor = Color.FromName(lstFontColor.SelectedItem.Text);

            // Update the picture.
            if (chkPicture.SelectedValue != null)
                imgDefault.ImageUrl = chkPicture.SelectedValue;

            // Update font size.
            try
            {
                if (Int32.Parse(txtFontSize.Text) > 0)
                {
                    lblGreeting.Font.Size =
                        FontUnit.Point(Int32.Parse(txtFontSize.Text));
                }
            }
            catch
            {
                // Use error handling to ignore invalid value.
            }

            // Update the sender name.
            lblSender.Text = "";
            if (!String.IsNullOrEmpty(txtSender.Text))
            {
                lblSender.Text = "From: " + txtSender.Text;
            }

            // Update the border style.
            pnlCard.BorderStyle = (BorderStyle)Int32.Parse(lstBorder.SelectedItem.Value);

            // Set the text.
            lblGreeting.Text = txtGreeting.Text;
        }

    }
}
