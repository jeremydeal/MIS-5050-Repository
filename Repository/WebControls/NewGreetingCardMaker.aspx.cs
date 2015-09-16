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

                // Set default picture.
                chkPicture.SelectedIndex = 0;
                imgDefault.ImageUrl = chkPicture.SelectedValue;

                // Set border style options...
                List<ListItem> borderStyles = new List<ListItem>();
                borderStyles.Add(
                    new ListItem(
                        BorderStyle.None.ToString(),
                        ((int)BorderStyle.None).ToString()
                    ));
                borderStyles.Add(
                    new ListItem(
                        BorderStyle.Double.ToString(),
                        ((int)BorderStyle.Double).ToString()
                    ));
                borderStyles.Add(
                    new ListItem(
                        BorderStyle.Solid.ToString(),
                        ((int)BorderStyle.Solid).ToString()
                    ));

                // Set default border style.
                lstBorder.Items.AddRange(borderStyles.ToArray());
                lstBorder.SelectedIndex = 0;
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
            UpdateCardAppearance();
            UpdateCardText();
        }

        private void UpdateCardText()
        {
            lblSender.Text = "";
            if (!String.IsNullOrEmpty(txtSender.Text))
            {
                lblSender.Text = "From: " + txtSender.Text;
            }

            lblGreeting.Text = txtGreeting.Text;
        }

        private void UpdateCardAppearance()
        {
            pnlCard.BackColor = Color.FromName(lstBackColor.SelectedItem.Text);
            pnlCard.ForeColor = Color.FromName(lstFontColor.SelectedItem.Text);
            pnlCard.BorderStyle = (BorderStyle)Int32.Parse(lstBorder.SelectedItem.Value);

            UpdateCardImage();
            UpdateCardFont();
        }

        private void UpdateCardFont()
        {
            lblGreeting.Font.Name = lstFontName.SelectedItem.Text;

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
                lblGreeting.Font.Size = FontUnit.Point(32);
            }
        }

        private void UpdateCardImage()
        {
            if (chkPicture.SelectedValue != null)
                imgDefault.ImageUrl = chkPicture.SelectedValue;
        }
    }
}
