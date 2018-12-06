<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TreeControlTest.aspx.vb" Inherits="TreeviewTest.TreeControlTest" %>

<%@ Register Assembly="TreeviewTest" Namespace="TreeviewTest" TagPrefix="cc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="searchtest"></asp:TextBox>
            <asp:Button ID="bTest" runat="server" OnClick="bTest_Click" />

        </div>
        <cc3:TreeControl ID="tcTest" SearchTextBoxId="searchtest" CheckBox="true" runat="server" />

    </form>
</body>
</html>
