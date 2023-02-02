using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeesMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        localhost.WS DataFromGridView = new localhost.WS();
        DataSet ds = DataFromGridView.GetAllEmployeesService();
        this.GridViewAllEmployees.DataSource = ds.Tables["employees"];
        this.GridViewAllEmployees.DataBind();
        
    }

  
    protected void GridViewAllEmployees_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridViewAllEmployees.PageIndex = e.NewPageIndex;
        GridViewAllEmployees.DataBind();
    }


    protected void GridViewAllEmployees_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EmployeeCard")
        {
            //Response.Redirect("EmployeePage.aspx");
            object row = e.CommandArgument;
            int RowNumber = Convert.ToInt32(row);
            //string Id = ((GridView)sender).Rows[RowNumber].Cells[1].Text;
            int Id = int.Parse(((GridView)sender).Rows[RowNumber].Cells[1].Text);
            Response.Redirect("EmployeePage.aspx?Id=" + Id); 
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewEmployee.aspx");
    }
}