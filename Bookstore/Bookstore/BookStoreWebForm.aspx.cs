/*
 * 
 * Andrew Larkins
 * Cis-3342-1
 * Bookstore Project
 * 09/19/20
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using BookLibrary;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Diagnostics;

namespace Bookstore
{
    public partial class BookStoreWebForm : System.Web.UI.Page
    {
        Student student = new Student();
        ArrayList orderedBooksArrayList = new ArrayList();
        DBConnect bookDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet bookDS;
                String strSQL = "SELECT * FROM Books ORDER BY basePrice DESC";
                //String getHarryPotter = "Select * From Books Where Authors = 'J.K. Rowling'";
                bookDS = bookDB.GetDataSet(strSQL);
                gvBooks.DataSource = bookDS;
                String[] price = new string[1];
                price[0] = "BasePrice";
                //gvBooks.Columns[4].Visible = false;
                gvBooks.DataKeyNames = price;
                gvBooks.DataBind();
            }
        }

        // Submit button event handler.
        protected void btnStudentSubmit_Click(object sender, EventArgs e)
        {
            Validate validator = new Validate();

            String id = txtStudentID.Text;
            String name = txtName.Text;
            String address = txtAddress.Text;
            String phoneNum = txtPhoneNum.Text;
            String campus = ddlCampus.Text;

            if (!validator.isValidID(id))
            {
                lblErrorMessage.Text = "Invalid id, must be 8 digits...";
                lblErrorMessage.Visible = true;
            }
            else if (!validator.isValidName(name))
            {
                lblErrorMessage.Text = "Invalid name, can't be blank...";
                lblErrorMessage.Visible = true;
            }
            else if (!validator.isValidAddress(address))
            {
                lblErrorMessage.Text = "Invalid address, can't be blank...";
                lblErrorMessage.Visible = true;
            }
            else if (!validator.isValidPhoneNum(phoneNum))
            {
                lblErrorMessage.Text = "Invalid phone number, must be 10 digits...";
                lblErrorMessage.Visible = true;
            }
            else
            {
                student.Id = id;
                student.Name = name;
                student.Address = address;
                student.PhoneNum = phoneNum;
                student.Campus = campus;

                lblStudentId.Text = student.Id.ToString();
                lblName.Text = student.Name.ToString();
                lblAddress.Text = student.Address.ToString();
                lblPhoneNum.Text = student.PhoneNum.ToString();
                lblCampus.Text = student.Campus.ToString();

                makeGridViewVisible();

            }
        } // end go button

        // Order book button that displays the order receipt
        protected void btnOrder_Click(object sender, EventArgs e)
        {
            DropDownList ddlBookFormat;
            DropDownList ddlRentBuy;
            TextBox quantity;

            for (int row = 0; row < gvBooks.Rows.Count; row++)
            {
                double price = Convert.ToDouble(gvBooks.DataKeys[row].Value);
                ddlBookFormat = (DropDownList)gvBooks.Rows[row].FindControl("ddlFormat");
                ddlRentBuy = (DropDownList)gvBooks.Rows[row].FindControl("ddlRentBuy");
                quantity = (TextBox)gvBooks.Rows[row].FindControl("txtQuantity");

                if (ddlRentBuy.SelectedValue.ToString() == "rent"
                    && ddlBookFormat.SelectedValue.ToString() == "hardcover")
                {
                    price = price * 2;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "rent"
                    && ddlBookFormat.SelectedValue.ToString() == "paper-back")
                {
                    price = price * .50;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "rent"
                    && ddlBookFormat.SelectedValue.ToString() == "e-book")
                {
                    price = price * 0.10;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "buy"
                    && ddlBookFormat.SelectedValue.ToString() == "e-book")
                {
                    price = price * 0.25;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "buy"
                    && ddlBookFormat.SelectedValue.ToString() == "hardcover")
                {
                    price = price * 3;
                }
                else if (ddlRentBuy.SelectedValue.ToString() == "buy"
                    && ddlBookFormat.SelectedValue.ToString() == "paper-back")
                {
                    price = price * 1;
                }

                int rentQuantity = 0;
                int buyQuantity = 0;

                CheckBox checkBox = (CheckBox)gvBooks.Rows[row].FindControl("chkSelectBook");
                if (checkBox.Checked)
                {
                    OrderedBook book = new OrderedBook();
                    book.Isbn = gvBooks.Rows[row].Cells[3].Text;
                    book.Title = gvBooks.Rows[row].Cells[1].Text;
                    book.Type = ddlBookFormat.SelectedValue.ToString();
                    book.RentBuy = ddlRentBuy.SelectedValue.ToString();
                    book.Price = price;
                    
                    book.Quantity = Int32.Parse(quantity.Text.ToString());
                    book.TotalPrice = price * Convert.ToUInt32(quantity.Text.ToString());
                    orderedBooksArrayList.Add(book);
                    
                    if (book.RentBuy == "rent")
                    {
                        rentQuantity = rentQuantity + book.Quantity;
                    }
                    else if (book.RentBuy == "buy")
                    {
                        buyQuantity = buyQuantity + book.Quantity;
                    }
                    String sqlUpdate = "UPDATE Books SET TotalSales + " + 
                        book.TotalPrice + ", " + "TotalQuantityRented = TotalQuantityRented + " 
                        + rentQuantity + ", " + "TotalQuantitySold = TotalQuantitySold " + buyQuantity + 
                        " WHERE Title = '" + book.Title + "'" ;
                    bookDB.DoUpdate(sqlUpdate);
                    }

            } // end loop of rows.
            
            makeNextGridViewVisible();
            BuildTheOrder();
            gvBooks.Visible = false;

        }  // end order button event handler

        // method to make stuff visible, hide some
        private void makeGridViewVisible()
        {

            gvBooks.Visible = true;
            btnOrder.Visible = true;

            lblTempleBookstore.Visible = false;
            lblFillOutForm.Visible = false;
            lblEnterID.Visible = false;
            lblEnterName.Visible = false;
            lblEnterAddress.Visible = false;
            lblEnterNum.Visible = false;
            txtStudentID.Visible = false;
            txtName.Visible = false;
            txtAddress.Visible = false;
            txtPhoneNum.Visible = false;
            lbltheCampus.Visible = false;
            ddlCampus.Visible = false;
            btnStudentSubmit.Visible = false;
        }

        // make stuff visible, hide some
        private void makeNextGridViewVisible()
        {
            btnOrder.Visible = false;
            lblOrderDisplay.Visible = true;
            lbldisplay1.Visible = true;
            lblDisplay2.Visible = true;
            lblDisplay3.Visible = true;
            lblDisplay4.Visible = true;
            lblDisplay5.Visible = true;
            lblStudentId.Visible = true;
            lblName.Visible = true;
            lblAddress.Visible = true;
            lblPhoneNum.Visible = true;
            lblCampus.Visible = true;
            gvOutput.Visible = true;
            btnOpenManagementGV.Visible = true;
        }

        public void BuildTheOrder()
        {
            btnStartOver.Visible = true;
            Debug.WriteLine(orderedBooksArrayList);
            gvOutput.DataSource = orderedBooksArrayList;
            gvOutput.DataBind();

            int totalQuantity = 0;
            double totalCost = 0;

            for(int row = 0; row < gvOutput.Rows.Count; row++)
            {
                totalQuantity = totalQuantity + int.Parse(gvOutput.Rows[row].Cells[5].Text);
                totalCost = totalCost + double.Parse(gvOutput.Rows[row].Cells[6].Text, System.Globalization.NumberStyles.Currency);
                gvOutput.Columns[0].FooterText = "Total:";
                gvOutput.Columns[5].FooterText = totalQuantity.ToString();
                gvOutput.Columns[6].FooterText = totalCost.ToString("C2");
                gvOutput.Columns[0].FooterStyle.ForeColor = Color.Blue;
                gvOutput.Columns[5].FooterStyle.ForeColor = Color.Blue;
                gvOutput.Columns[6].FooterStyle.ForeColor = Color.Blue;

                gvOutput.DataBind();
            }
        }

        // reset form and start over
        protected void btnStartOver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookStoreWebForm.aspx");
        }

        protected void btnOpenManagementGV_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT Title, TotalSales, TotalQuantityRented," +
                " TotalQuantitySold FROM Books ORDER BY TotalSales DESC";
            gvManagement.DataSource = bookDB.GetDataSet(sqlSelect);
            gvManagement.DataBind();
            gvManagement.Visible = true;
        }
    } // end class
} // end namespace
