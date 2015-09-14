<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Advanced_Controls.aspx.cs" Theme="GreetingCardPanel" Inherits="Advanced_Controls_Advanced_Controls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advanced Controls</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- WIZARD -->
        <h3>Wizard</h3>
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" OnFinishButtonClick="Wizard1_FinishButtonClick">
            <SideBarStyle BorderWidth="2" BorderColor="Black" BorderStyle="Inset" Width="120" />
            <SideBarButtonStyle ForeColor="Black" Font-Underline="False" />
            <WizardSteps>
                <asp:WizardStep ID="WizardStepBackground" runat="server" Title="Background Style" AllowReturn="False" StepType="Auto">
                    <div style="border: thin ridge; padding: 20px; font-size: x-small; width: 293px; font-family: Verdana; height: auto; background-color: lightyellow">
                        Choose a background color:<br />

                        <asp:DropDownList ID="lstBackColor" runat="server" Height="22px" Width="194px">
                            <asp:ListItem Value="White">White</asp:ListItem>
                            <asp:ListItem Value="Red">Red</asp:ListItem>
                            <asp:ListItem Value="Green">Green</asp:ListItem>
                            <asp:ListItem Value="Blue">Blue</asp:ListItem>
                            <asp:ListItem Value="Yellow">Yellow</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />

                        Choose a border style:<br />
                        <asp:RadioButtonList ID="lstBorder" runat="server" Height="59px" Width="177px" Font-Size="X-Small" />
                        <br />
                        <br />
                    </div>
                </asp:WizardStep>

                <asp:WizardStep ID="WizardStepFont" runat="server" Title="Font Style" AllowReturn="False" StepType="Auto">
                    <div style="border: thin ridge; padding: 20px; font-size: x-small; width: 293px; font-family: Verdana; height: auto; background-color: lightyellow">
                        Choose a font:<br />
                        <asp:DropDownList ID="lstFontName" runat="server" Height="22px" Width="194px" />
                        <br />
                        <br />

                        Choose a font color:<br />
                        <asp:DropDownList ID="lstFontColor" runat="server" Height="22px" Width="194px">
                            <asp:ListItem Value="White">White</asp:ListItem>
                            <asp:ListItem Value="Red">Red</asp:ListItem>
                            <asp:ListItem Value="Green">Green</asp:ListItem>
                            <asp:ListItem Value="Blue">Blue</asp:ListItem>
                            <asp:ListItem Value="Yellow">Yellow</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />

                        Specify a numeric font size:<br />
                        <asp:TextBox ID="txtFontSize" runat="server" />
                        <br />
                        <br />
                    </div>
                </asp:WizardStep>

                <asp:WizardStep ID="WizardStepText" runat="server" Title="Text" AllowReturn="False" StepType="Finish">
                    <div style="border: thin ridge; padding: 20px; font-size: x-small; width: 293px; font-family: Verdana; height: auto; background-color: lightyellow">

                        <asp:Label Text="Add the Default Picture" runat="server" />
                        <asp:RadioButtonList ID="chkPicture" runat="server" />
                        <br />
                        <br />

                        Enter the greeting text below:<br />
                        <asp:TextBox ID="txtGreeting" runat="server" Height="85px" Width="240px" TextMode="MultiLine" />
                        <br />
                        <br />

                        Enter your name:<br />
                        <asp:TextBox ID="txtSender" runat="server" Height="22px" Width="240px" TextMode="SingleLine" />
                        <br />
                        <br />
                    </div>
                </asp:WizardStep>

                <asp:WizardStep ID="WizardStepDisplayCard" runat="server" Title="Display Card" AllowReturn="False" StepType="Complete">
                    <div style="position: relative; float: right; border: 1px solid black; margin-left: 30px;">
                        <asp:Panel ID="pnlCard" SkinID="greetingPanel" Style="z-index: 101;" Height="507px" Width="339px" runat="server">
                            <br />
                            &nbsp;
			        <asp:Label ID="lblGreeting" runat="server" Height="150px" Width="256px" />
                            <br />
                            <br />
                            <br />
                            <asp:Image ID="imgDefault" runat="server" Height="160px" Width="212px" />
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="lblSender" runat="server" Font-Size="30px" Height="100px" Width="256px" />
                        </asp:Panel>
                    </div>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>

        <br />
        <br />

        <!-- CALENDAR -->
        <h3>Calendar</h3>
        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_OnDayRender" Font-Size="9pt" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="800">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <DayStyle Height="100" Width="100" BorderWidth="1pt" BorderStyle="Solid" BorderColor="Black" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>

        <br />
        <br />

        <!-- AD ROTATOR -->
        <h3>AdRotator</h3>
        <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="Ads.xml" Target="_blank" Height="200px" BorderWidth="2" BorderColor="Black" BorderStyle="Outset" />

        <br />
        <br />

        <!-- FILE UPLOAD -->
        <h3>FileUpload</h3>
        <asp:Label runat="server" Text="Please upload one or more images:"/>
        <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="Black" BorderWidth="2" BorderStyle="Solid" AllowMultiple="True" />
        <asp:Button ID="cmdUpload" runat="server" Text="Upload" OnClick="cmdUpload_OnClick"/>
        <br/>
        <asp:Label runat="server" ID="lblUploadInfo"/>
    </form>
</body>
</html>
