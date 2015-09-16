<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorTEst.aspx.cs" Inherits="PLAYIN_ErrorTEst" Trace="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Value 1</p>
            <asp:TextBox runat="server" ID="txt1" />
            <p>Value 2</p>
            <br/>
            <asp:TextBox runat="server" ID="txt2" />
            <br/>
            <asp:Button runat="server" ID="cmdSubmit" OnClick="cmdSubmit_OnClick" Text="Submit" />
            <br/><br/>
            <asp:Label runat="server" ID="lbl1" />

        </div>
    </form>
</body>
</html>
