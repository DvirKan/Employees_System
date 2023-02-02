using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for CoachWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class WS : System.Web.Services.WebService
{

    public WS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    // שאילתה לקבלת עובדים
    [WebMethod]
    public DataSet GetAllEmployeesService()
    {
        Employee emp = new Employee();
        return emp.GetAllEmployees();
    }
    
    
    // קבלת מידע על עובד ספציפי
    [WebMethod]
    public DataSet GetEmployeeDataService(int Id)
    {
        Employee emp = new Employee();
        return emp.GetEmployeeData(Id);
    }
    

    // הוספת עובד
    [WebMethod] 
    public void InsertEmployeeService(string FullName, int Id, string Address, DateTime DateOfBirth, string PhoneNumber, DateTime firstDay, string Img)
    {
        Employee emp = new Employee();
        emp.InsertEmployee(FullName, Id, Address, DateOfBirth, PhoneNumber, firstDay, Img);
    }

    
    // מחיקת עובד
    [WebMethod]
    public void DeleteEmployeeService(int Id)
    {
        Employee emp = new Employee();
        emp.DeleteEmployee(Id);
    }
    

    // עדכון עובד פרטים הכרחיים
    [WebMethod]
    public void updateEmployeeNecessaryService(string FullName, string Address, string PhoneNumber, int Id)
    {
        Employee emp = new Employee();
        emp.UpdateEmployeeNecessary(FullName, Address, PhoneNumber, Id);
    }

    // קבלת ימי העדרות לפי עובד
    [WebMethod] 
    public DataSet GetDaysAway(int Id)
    {
        DaysAway days = new DaysAway();
        return days.GetDaysAway(Id);
    }

    //הוספת יום העדרות
    [WebMethod] 
    public void InsertDayAwayService(int Id, DateTime DayAway, string Kind)
    {
        DaysAway days = new DaysAway();
        days.InsertDayAway (Id,DayAway,Kind);
    }

    // קבלת ימי חופש
    [WebMethod]
    public int GetVacationDaysCountService(int Id)
    {
        DaysAway days = new DaysAway();
        return days.GetCountOfDaysAway(Id);
    }
    
    // מחיקת יום חופש
    [WebMethod]
    public void DeleteVacationDayService(int Id, DateTime DateAway)
    {
        DaysAway days = new DaysAway();
        days.DeleteVacationDay(Id, DateAway);
    }

}




