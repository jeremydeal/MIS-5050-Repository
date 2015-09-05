<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurrencyConverter.aspx.cs" Inherits="WebForm_CurrencyConverter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Currency Converter</title>
</head>
<body>
    <form id="form" runat="server">
        <h3>Currency Converter</h3>
        <div style="border-right: thin ridge; padding-right: 20px; border-top: thin ridge; padding-left: 20px; padding-bottom: 20px; border-left: thin ridge; width: 531px; padding-top: 20px; border-bottom: thin ridge; font-family: Verdana; min-height: 211px; background-color: #FFFFE8">
            Convert:&nbsp;
            <input type="text" id="US" runat="server" />
            &nbsp;U.S. dollars to&nbsp;
            <select id="Currency" runat="server"/>
            <br/><br/>
            <input type="submit" value="OK" id="Convert" runat="server" OnServerClick="Convert_OnServerClick" />
            <input type="submit" value="Show Graph" id="ShowGraph" runat="server" OnServerClick="ShowGraph_OnServerClick"/>
            <br/><br/>
            <img id="Graph" src="" alt="Currency Graph" runat="server"/>
            <br/><br/>
            <p style="font-weight:bold" id="Result" runat="server"></p>
        </div>

        <h3>Links</h3>
        <a href="SecondPage.aspx">Link to SecondPage.aspx</a>
        <input type="submit" id="redirect" value="Response.Redirect to SecondPage.aspx" runat="server" onserverclick="redirect_OnServerClick" />
        <input type="submit" id="transfer" value="Server.Transfer to SecondPage.aspx" runat="server" onserverclick="transfer_OnServerClick" />
    </form>
</body>
</html>
