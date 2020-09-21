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
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + id + " is invalid." + "');", true);
            }
            else if (!validator.isValidName(name))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + name + " is invalid." + "');", true);

            }
            else if (!validator.isValidAddress(address))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + address + " is invalid." + "');", true);
            }
            else if (!validator.isValidPhoneNum(phoneNum))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + phoneNum + " is invalid." + "');", true);
            }
            else
            {
                Student student = new Student(id, name, address, phoneNum, campus);
                gvBooks.Visible = true;
            }
        } // end button



    }

}
