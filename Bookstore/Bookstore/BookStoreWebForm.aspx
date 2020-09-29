<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookStoreWebForm.aspx.cs" Inherits="Bookstore.BookStoreWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temple Book Store</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-color: lightgray">
    <form id="form1" runat="server" >
        <div class="container-fluid" >
        <div id ="studentInfo" class="text-center" >
            
            <asp:Label ID="lblTempleBookstore" runat="server" Font-Bold="True" Text="Temple Book Store" Font-Size="X-Large" ForeColor="#CC0000">Temple Book Store</asp:Label>
            <br />
            <asp:Label ID="lblFillOutForm" class="text-center" runat="server" Text="Fill out student form:" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="lblEnterID" runat="server" Text="Student ID:" Font-Bold="True" Font-Size="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStudentID" runat="server" Width="142px"></asp:TextBox>
            <br />
            <asp:Label ID="lblEnterName" runat="server" Text="Name:" Font-Bold="True" Font-Size="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server" Width="157px"></asp:TextBox>
            <br />
            <asp:Label ID="lblEnterAddress" runat="server" Text="Address:" Font-Bold="True" Font-Size="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" Width="314px"></asp:TextBox>
            <br />
            <asp:Label ID="lblEnterNum" runat="server" Text="Phone #:" Font-Bold="True" Font-Size="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPhoneNum" runat="server" Width="117px"></asp:TextBox>
            <br />
            <asp:Label ID="lbltheCampus" runat="server" Text="Campus:" Font-Bold="True" Font-Size="Medium"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCampus" runat="server" Font-Bold="True" Font-Size="Medium">
                <asp:ListItem>Main</asp:ListItem>
                <asp:ListItem>TUCC</asp:ListItem>
                <asp:ListItem>Ambler</asp:ListItem>
                <asp:ListItem>Tokyo</asp:ListItem>
                <asp:ListItem>Rome</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="(error)" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnStudentSubmit" runat="server" Height="44px" OnClick="btnStudentSubmit_Click" Text="Go!" Width="138px" Font-Bold="True" Font-Size="X-Large" />
            <br />
            
            
        </div>

        <div id="gvBooksDiv" class="text-center" >
            <br />
            <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" Visible="False" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="Select Book">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectBook" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Authors" HeaderText="Authors" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="BasePrice" DataFormatString="{0:c}" HeaderText="Base Price" />
                    <asp:TemplateField HeaderText="Select Format">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlFormat" runat="server">
                                <asp:ListItem>hardcover</asp:ListItem>
                                <asp:ListItem>paper-back</asp:ListItem>
                                <asp:ListItem>e-book</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rent/Buy">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlRentBuy" runat="server">
                                <asp:ListItem>rent</asp:ListItem>
                                <asp:ListItem>buy</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblQuantityError" runat="server" Text="Enter A Quantity" Visible="False" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="btnOrder" runat="server" Height="44px" OnClick="btnOrder_Click" Text="Order!" Visible="False" Width="138px" Font-Bold="True" Font-Size="X-Large" />
            <br />
            </div> <!-- End gvBookDiv -->

            <div id="gvOutputDiv" class="text-center" >
            <asp:Label ID="lblErrorMessage2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="(error)" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblOrderDisplay" runat="server" Text="Order" Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <strong>
            <br />
            </strong>
            <asp:Label ID="lbldisplay1" runat="server" Text="Student ID:" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
            <asp:Label ID="lblStudentId" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <strong>
            <br />
            </strong>
            <asp:Label ID="lblDisplay2" runat="server" Text="Name:" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblName" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="lblDisplay3" runat="server" Text="Address:" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAddress" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="lblDisplay4" runat="server" Text="Phone Number:" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPhoneNum" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="lblDisplay5" runat="server" Text="Campus:" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
            <asp:Label ID="lblCampus" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <strong>
            <br />
            </strong>
            <asp:GridView ID="gvOutput" runat="server" Visible="False" AutoGenerateColumns="False" ShowFooter="true" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="Type" HeaderText="Type" />
                    <asp:BoundField DataField="RentBuy" HeaderText="Rent/Buy" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="totalPrice" HeaderText="TotalPrice" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnStartOver" runat="server" OnClick="btnStartOver_Click" Text="Start Over!" Visible="False" Font-Bold="True" Font-Size="X-Large" />
            <br />
            </div> <!-- End gvOutputDiv -->

            <div id="gvManagementDiv" class="text-center">

                <asp:Button ID="btnOpenManagementGV" runat="server" OnClick="btnOpenManagementGV_Click" Text="Open Management Report" Visible="False" Font-Bold="True" Font-Size="X-Large" />
                <br />
                <br />
                <br />
                <br />
                <asp:GridView ID="gvManagement" runat="server" AutoGenerateColumns="False" Visible="False" HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="TotalSales" HeaderText="Total Sales" />
                        <asp:BoundField DataField="TotalQuantityRented" HeaderText="Quantity Rented" />
                        <asp:BoundField DataField="TotalQuantitySold" HeaderText="Quantity Sold" />
                    </Columns>
                </asp:GridView>

                <br />
                <br />
                <br />
                <br />

            </div>
            </div>
    </form>
</body>
</html>
