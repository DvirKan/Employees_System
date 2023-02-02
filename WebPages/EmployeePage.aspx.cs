using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;


public partial class EmployeePage : System.Web.UI.Page
{
    int Id = 0;
    localhost.WS WebServices = new localhost.WS(); // for dry
    int VacationDays = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        Id = int.Parse(Request.QueryString["Id"]); // for dry
        
        if (!IsPostBack)
        {
            showData();
            this.AddDay.Visible = false;
            this.DateAway.Visible = false;
            this.Kind.Visible = false;
            this.Submit.Visible = false;
            this.DaysLeft.Visible = false;
            YesNoBtnsNotVis();
        }

    }

   // כפתורי ביטול ומחיקה
    private void YesNoBtnsNotVis()
    {
        this.YesBtn.Visible = false;
        this.NoBtn.Visible = false;
    }

    // הצגת מידע של עובד בהתבסס על תז
    private void showData()
    {
        DataSet ds = WebServices.GetEmployeeDataService(Id);
        this.GridView1.DataSource = ds.Tables["employees"];
        this.GridView1.DataBind();
    }

    // הצגת ימי היעדרות
    private void ShowDaysAway() 
    {        
        DataSet ds = WebServices.GetDaysAway(Id);
        this.GridViewDays.DataSource = ds.Tables["DaysAway"];
        this.GridViewDays.DataBind();
    }


    //כפתור העריכה
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        showData();
    }

    //ביטול עריכה
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        showData();
    }

    //עדכון פרטי עובד
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string FullName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        int Id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[2].Text);
        string Address = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string PhoneNumber = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;


        if (Regex.IsMatch(FullName, @"^[0-9a-z]$") || !Regex.IsMatch(PhoneNumber, @"^[0-9]{10}$") || Regex.IsMatch(Address, @"^[0-9]$"))
        {
            Response.Write("<script>alert('הכנס קלט תקין');</script>");
        }

        else if (FullName == "" || PhoneNumber == "" || Address == "")
        {
            Response.Write("<script>alert('הכנס קלט תקין');</script>");
        }
    
        else
        {
            try
            {
                WebServices.updateEmployeeNecessaryService(FullName, Address, PhoneNumber, Id);
                GridView1.EditIndex = -1;
                showData();
            }
            catch
            {
                Response.Write("<script>alert('כבר קיים עובד עם מספר טלפון זה');</script>");
            }

            
        }

    }

    // חישוב וכתיבת ימי חופשה
    private void CalcVacationDays()
    {
        VacationDays = WebServices.GetVacationDaysCountService(Id);
        int DaysLeftCalc = 20 - VacationDays;
        this.DaysLeft.Text = "נותרו " + DaysLeftCalc + " ימי חופש ";
        this.DaysLeft.Visible = true;
    }

    // לחיצה על הצגת ימי העדרות
    protected void ShowDaysBtn_Click(object sender, EventArgs e)
    {
        ShowDaysAway();
        this.ShowDaysBtn.Visible = false;
        this.AddDay.Visible = true;
        CalcVacationDays();
    }

    // לחיצה על הוספת יום העדרות
    protected void AddDay_Click(object sender, EventArgs e)
    {
        this.AddDay.Visible = false;
        this.DateAway.Visible = true;
        this.Kind.Visible = true;
        this.Submit.Visible = true;
    }

    //אישור הוספת יום ההעדרות
    protected void Submit_Click(object sender, EventArgs e)
    {
        //string NewFormat = string.Format("{0:MM/dd/yyyy}", DateAway);
        //DateTime LoadedDate = DateTime.ParseExact(DateAway.Text, "d", null);
        DateTime MyDate;
       
        if (!DateTime.TryParse(DateAway.Text, out MyDate))
        {
            Response.Write("<script>alert('הכנס תאריך תקין');</script>");

        }
            
       else
        {
            try
            {
                VacationDays = WebServices.GetVacationDaysCountService(Id);
                if (VacationDays < 20)
                {
                    this.Submit.Visible = true;
                    WebServices.InsertDayAwayService(Id, DateTime.Parse(DateAway.Text), Kind.Text);
                    CalcVacationDays();
                    ShowDaysAway();                  
                }

                else Response.Write("<script>alert('מכסת ימי החופשה נגמרה!');</script>");
            }
            catch
            {
                Response.Write("<script>alert('כבר מוזן יום העדרות בתאריך זה');</script>");
            }
        }

    }

    //מחיקה
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        this.YesBtn.Visible = true;
        this.NoBtn.Visible = true;
        Response.Write("<script>alert('בחר האם למחוק או לבטל את מחיקת העובד');</script>");
        //Response.Write("<script> ans = confirm('אתה בטוח שאתה רוצה למחוק את העובד?'); if(ans ==true) </script>");
    }

    // מחיקה סופית
    protected void YesBtn_Click(object sender, EventArgs e)
    {
        WebServices.DeleteEmployeeService(Id);
        Response.Redirect("EmployeesMain.aspx");

    }

    // ביטול מחיקה
    protected void NoBtn_Click(object sender, EventArgs e)
    {
        YesNoBtnsNotVis();
    }
    protected void ToMainBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeesMain.aspx");
    }
    protected void GridViewDays_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DateTime VacationDay = DateTime.Parse((GridViewDays.Rows[e.RowIndex].Cells[1]).Text);
        WebServices.DeleteVacationDayService(Id, VacationDay);
        ShowDaysAway();
        CalcVacationDays();
    }
}