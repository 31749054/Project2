<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Media1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            id:<asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            <asp:Button ID="savebtn" OnClick= "savebtn_Click" runat="server" Text="save" />
            <asp:Button ID="showbtn" OnClick="showbtn_Click" runat="server" Text="Show" />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Image ID="Image1" runat="server" />
        </div>
    </form>
</body>
</html>
