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

namespace Bookstore
{
    public partial class BookStoreWebForm : System.Web.UI.Page
    {

        Student student = new Student();


        protected void Page_Load(object sender, EventArgs e)
        {
            DBConnect bookDB = new DBConnect();
            DataSet bookDS;
            String strSQL = "SELECT * FROM Books";
            //String getHarryPotter = "Select * From Books Where Authors = 'J.K. Rowling'";
            bookDS = bookDB.GetDataSet(strSQL);
            gvBooks.DataSource = bookDS;
            gvBooks.DataBind();
            

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
                gvBooks.Visible = true;
                btnOrder.Visible = true;
            }
        } // end go button

        // Order book button that displays the order receipt
        protected void btnOrder_Click(object sender, EventArgs e)
        {


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
            lblStudentId.Text = student.Id.ToString();
            lblName.Text = student.Name.ToString();
            lblAddress.Text = student.Address.ToString();
            lblPhoneNum.Text = student.PhoneNum.ToString();
            lblCampus.Text = student.Campus.ToString();

            gvOutput.Visible = true;

        }
    }

}
