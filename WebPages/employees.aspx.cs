using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class employees : System.Web.UI.Page
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
}