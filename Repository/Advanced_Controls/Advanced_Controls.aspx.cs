using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Advanced_Controls_Advanced_Controls : System.Web.UI.Page
{
    private string uploadDirectory;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            #region Initialize Greeting Card Wizard
            // Set font options.
            lstFontName.Items.Add("Times New Roman");
            lstFontName.Items.Add("Arial");
            lstFontName.Items.Add("Verdana");
            lstFontName.Items.Add("Tahoma");

            // Set (checkbox list) picture choices.
            string directory = "../WebControls/";
            SortedDictionary<string, string> pictures = new SortedDictionary<string, string>();
            pictures["Happy Birthday"] = directory + "birthday.png";
            pictures["Merry Christmas"] = directory + "christmas.png";
            pictures["Get Well Soon"] = directory + "get_well.gif";
            pictures["Happy Graduation"] = directory + "graduation.jpg";
            pictures["Happy Valentine's"] = directory + "valentine.jpg";

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
            #endregion

            // set upload directory for use by FileUpload1
            uploadDirectory = Path.Combine(Request.PhysicalApplicationPath, "Advanced_Controls", "Uploads");
        }
    }

    #region Calendar Render Event and Helper Methods
    protected void Calendar1_OnDayRender(object sender, DayRenderEventArgs e)
    {
        GenerateBirthdayLabels(e);
        SetCalendarVisibiltyAndSelection(e);
    }

    private void GenerateBirthdayLabels(DayRenderEventArgs e)
    {
        List<Label> labels = new List<Label>();

        Dictionary<string, DateTime> birthdays = new Dictionary<string, DateTime>();
        birthdays.Add("Jeremy", new DateTime(1988, 12, 25));

        foreach (var bd in birthdays)
        {
            string name = bd.Key;
            DateTime birthdate = bd.Value;
            DateTime compareDate = e.Day.Date;

            // is birthday before, after, or on the date being rendered?
            int dateComparison = CompareDatesIgnoreYear(compareDate, birthdate);

            // update Label with birthday announcements
            if (dateComparison == 0)
                labels.Add(
                    CreateLabel(String.Format("Happy birthday, {0}!", name), Color.LawnGreen));
            else if (dateComparison == 1) // compareDate is after
                labels.Add(
                    CreateLabel(String.Format("After {0}'s birthday.", name), Color.Black));
            else if (dateComparison == -1) // compareDate is before
                labels.Add(
                    CreateLabel(String.Format("Before {0}'s birthday.", name), Color.Black));
        }

        // add finished Label to Cell
        foreach (var lbl in labels)
        {
            e.Cell.Controls.Add(new LiteralControl("<br />"));
            e.Cell.Controls.Add(lbl);
        }
    }

    private static void SetCalendarVisibiltyAndSelection(DayRenderEventArgs e)
    {
        if (e.Day.IsWeekend)
            e.Day.IsSelectable = false;

        if (e.Day.IsOtherMonth)
            e.Cell.Controls.Clear();
    }

    private int CompareDatesIgnoreYear(DateTime compareDate, DateTime birthdate)
    {
        int offset = compareDate.Year - birthdate.Year;
        DateTime cDate = compareDate.AddYears(-offset);
        return cDate.CompareTo(birthdate);
    }

    private Label CreateLabel(string txt, Color color)
    {
        var lbl = new Label();
        lbl.Text = txt;
        lbl.ForeColor = color;
        return lbl;
    }
    #endregion


    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        UpdateCard();
    }

    #region File Upload Event and Helper Methods
    protected void cmdUpload_OnClick(object sender, EventArgs e)
    {
        // check that file is being submitted
        if (FileUpload1.PostedFiles.Count == 0)
            lblUploadInfo.Text = "No file specified.";
        else
        {
            UploadImageFilesToServer();
        }
    }

    private void UploadImageFilesToServer()
    {
        // sort files into valid and invalid
        List<HttpPostedFile> validFiles = new List<HttpPostedFile>();
        List<string> uploadedFilenames = new List<string>();
        List<string> rejectedFilenames = new List<string>();

        foreach (HttpPostedFile file in FileUpload1.PostedFiles)
            ValidateExtensionType(file, validFiles, rejectedFilenames);

        // save files to server; if any upload presents an error, add to rejected files list
        foreach (var file in validFiles)
            AttemptToSaveImageFiles(file, uploadedFilenames, rejectedFilenames);

        // generate an upload report for the label
        lblUploadInfo.Text = GenerateUploadMessage(uploadedFilenames, rejectedFilenames);
    }

    private static string GenerateUploadMessage(List<string> uploadedFilenames, List<string> rejectedFilenames)
    {
        StringBuilder message = new StringBuilder();

        if (uploadedFilenames.Count > 0)
        {
            message.Append("Files successfully uploaded:\n");
            foreach (var name in uploadedFilenames)
                message.AppendFormat("{0}\n", name);
        }

        if (message.Length > 0)
            message.Append("\n");

        if (rejectedFilenames.Count > 0)
        {
            message.Append("Rejected files:\n");
            foreach (var name in rejectedFilenames)
                message.AppendFormat("{0}\n", name);
        }

        return message.ToString();
    }

    private void AttemptToSaveImageFiles(HttpPostedFile file, List<string> uploadedFilenames, List<string> rejectedFilenames)
    {
        string serverFileName = Path.GetFileName(file.FileName);
        // NOTE: I can't get uploadDirectory to hold a value until this call, so I had to inline it; how the heck???
        string fullUploadPath =
            Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "Advanced_Controls", "Uploads"), serverFileName);

        try
        {
            file.SaveAs(fullUploadPath);
            uploadedFilenames.Add(serverFileName);
        }
        catch
        {
            rejectedFilenames.Add(serverFileName);
        }
    }

    private void ValidateExtensionType(HttpPostedFile file, List<HttpPostedFile> validFiles, List<string> rejectedFilenames)
    {
        // check extension
        string extension = Path.GetExtension(file.FileName);

        switch (extension.ToLower())
        {
            case ".bmp":
            case ".gif":
            case ".jpg":
            case ".jpeg":
            case ".png":
                validFiles.Add(file);
                break;
            default:
                rejectedFilenames.Add(Path.GetFileName(file.FileName));
                break;
        }
    }
    #endregion

    #region Wizard Helper Methods
    private void UpdateCard()
    {
        UpdateCardAppearance();
        UpdateCardText();
    }

    private void UpdateCardText()
    {
        lblSender.Text = "";
        if (!String.IsNullOrEmpty(txtSender.Text))
            lblSender.Text = "From: " + txtSender.Text;

        lblGreeting.Text = txtGreeting.Text;
    }

    private void UpdateCardAppearance()
    {
        pnlCard.BackColor = Color.FromName(lstBackColor.SelectedItem.Text);
        pnlCard.ForeColor = Color.FromName(lstFontColor.SelectedItem.Text);
        pnlCard.BorderStyle = (BorderStyle)Int32.Parse(lstBorder.SelectedItem.Value);

        UpdateCardFont();
        UpdateCardImage();
    }

    private void UpdateCardImage()
    {
        if (chkPicture.SelectedValue != null)
            imgDefault.ImageUrl = chkPicture.SelectedValue;
    }

    private void UpdateCardFont()
    {
        lblGreeting.Font.Name = lstFontName.SelectedItem.Text;

        try
        {
            if (Int32.Parse(txtFontSize.Text) > 0)
                lblGreeting.Font.Size = FontUnit.Point(Int32.Parse(txtFontSize.Text));
        }
        catch
        {
            lblGreeting.Font.Size = FontUnit.Point(32);
        }
    }

    #endregion
}