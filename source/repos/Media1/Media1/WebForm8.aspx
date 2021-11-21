<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="Media1.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 1208px;
            background-color: #CCCCFF;
        }
        .auto-style4 {
            margin-left: 80px;
            background-color: #FFCCFF;
        }
        </style>
</head>
<body style="height: 1222px; width: 1703px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            &nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Album"></asp:Label>
&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="351px" Width="738px" CssClass="auto-style4">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Tag" HeaderText="Tag" SortExpression="Tag" />
                <asp:BoundField DataField="Captured_by" HeaderText="Captured_by" SortExpression="Captured_by" />
                <asp:TemplateField HeaderText="Blog_image" SortExpression="Blog_image">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Blog_image") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        &nbsp;
                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("Blog_image") %>' Width="200px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Captured_date" HeaderText="Captured_date" SortExpression="Captured_date" />
            </Columns>
        </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UsersDBConnectionString %>" SelectCommand="SELECT [Id], [Tag], [Captured_by], [Blog_image], [Captured_date] FROM [Blogs]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
