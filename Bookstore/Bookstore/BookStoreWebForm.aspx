<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookStoreWebForm.aspx.cs" Inherits="Bookstore.BookStoreWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div id="gvBooks">
            <asp:GridView ID="gvBooks" runat="server" AllowSorting="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Select Book">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectBook" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Authors" HeaderText="Authors" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="BasePrice" DataFormatString="{0:c}" HeaderText="Price" />
                    <asp:TemplateField HeaderText="Select Format">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>hardcover</asp:ListItem>
                                <asp:ListItem>paper-back</asp:ListItem>
                                <asp:ListItem>e-book</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rent/Buy">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem>rent</asp:ListItem>
                                <asp:ListItem>buy</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
