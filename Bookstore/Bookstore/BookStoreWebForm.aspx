<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookStoreWebForm.aspx.cs" Inherits="Bookstore.BookStoreWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div id ="studentInfo">
            
            
            Temple Book Store<br />
            <br />
            Fill out student form to begin:<br />
            <asp:Label ID="lblEnterID" runat="server" Text="Student ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEnterName" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEnterAddress" runat="server" Text="Address:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEnterNum" runat="server" Text="Phone #:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>
            <br />
            Campus:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCampus" runat="server">
                <asp:ListItem>Main</asp:ListItem>
                <asp:ListItem>TUCC</asp:ListItem>
                <asp:ListItem>Ambler</asp:ListItem>
                <asp:ListItem>Tokyo</asp:ListItem>
                <asp:ListItem>Rome</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnStudentSubmit" runat="server" Height="47px" OnClick="btnStudentSubmit_Click" Text="Go!" Width="108px" />
            <br />
            
            
        </div>

        <div id="gvBooks">
            <br />
            <asp:GridView ID="gvBooks" runat="server" AllowSorting="True" AutoGenerateColumns="False" Visible="False">
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
