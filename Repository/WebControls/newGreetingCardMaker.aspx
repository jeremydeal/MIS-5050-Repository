<%@ Page Language="c#" Theme="GreetingCardPanel" Inherits="GreetingCardMaker.GreetingCardMaker" CodeFile="NewGreetingCardMaker.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Greeting Card Maker</title>
</head>
<body>
    <form runat="server">
        <div>

            <!-- card design wizard -->
            <div style="border: thin ridge; padding: 20px; font-size: x-small; width: 293px; font-family: Verdana; height: auto; background-color: lightyellow">
                Choose a background color:<br />

                <asp:DropDownList ID="lstBackColor" runat="server" Height="22px" Width="194px" AutoPostBack="True" OnSelectedIndexChanged="Control_IsChanged">
                    <asp:ListItem Value="White">White</asp:ListItem>
                    <asp:ListItem Value="Red">Red</asp:ListItem>
                    <asp:ListItem Value="Green">Green</asp:ListItem>
                    <asp:ListItem Value="Blue">Blue</asp:ListItem>
                    <asp:ListItem Value="Yellow">Yellow</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />

                Choose a border style:<br />
                <asp:RadioButtonList ID="lstBorder" runat="server" Height="59px" Width="177px" Font-Size="X-Small" AutoPostBack="True" OnSelectedIndexChanged="Control_IsChanged" />
                <br />
                <br />

                Choose a font:<br />
                <asp:DropDownList ID="lstFontName" runat="server" Height="22px" Width="194px" AutoPostBack="True" OnSelectedIndexChanged="Control_IsChanged" />
                <br />
                <br />

                Choose a font color:<br />
                <asp:DropDownList ID="lstFontColor" runat="server" Height="22px" Width="194px" AutoPostBack="True" OnSelectedIndexChanged="Control_IsChanged">
                    <asp:ListItem Value="White">White</asp:ListItem>
                    <asp:ListItem Value="Red">Red</asp:ListItem>
                    <asp:ListItem Value="Green">Green</asp:ListItem>
                    <asp:ListItem Value="Blue">Blue</asp:ListItem>
                    <asp:ListItem Value="Yellow">Yellow</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />

                Specify a numeric font size:<br />
                <asp:TextBox ID="txtFontSize" runat="server" AutoPostBack="True" OnTextChanged="Control_IsChanged" />
                <br />
                <br />

                <asp:Label Text="Add the Default Picture" runat="server" />
                <asp:RadioButtonList ID="chkPicture" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Control_IsChanged" />
                <br />
                <br />

                Enter the greeting text below:<br />
                <asp:TextBox ID="txtGreeting" runat="server" Height="85px" Width="240px" TextMode="MultiLine" AutoPostBack="True" OnTextChanged="Control_IsChanged" />
                <br />
                <br />

                Enter your name:<br />
                <asp:TextBox ID="txtSender" runat="server" Height="22px" Width="240px" TextMode="SingleLine" AutoPostBack="True" OnTextChanged="Control_IsChanged" />
                <br />
                <br />

                <asp:Button ID="cmdUpdate" runat="server" Height="24px" Width="71px" Text="Update" OnClick="cmdUpdate_Click" />
            </div>

            <!-- card display panel -->
            <div style="position: absolute; top: 8px; left: 375px; border: 1px solid black; padding: 20px; height: auto; width: auto;">
                <asp:Panel ID="pnlCard" SkinID="greetingPanel" Style="z-index: 101; position: relative;" Height="507px" Width="339px" runat="server">
                    <br />
                    &nbsp;
			        <asp:Label ID="lblGreeting" runat="server" Height="150px" Width="256px" Font-Size="32"/>
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

        </div>
    </form>
</body>
</html>
