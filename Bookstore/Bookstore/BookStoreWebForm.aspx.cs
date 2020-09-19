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
        
    }
}
