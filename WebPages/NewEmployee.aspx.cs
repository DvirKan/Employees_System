using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public int IsLegalAge(DateTime BD)
    {
        int age = 0;
        DateTime BirthDate = DateTime.Parse(DateOfBirthTB.Text);
        age = DateTime.Now.Year - BirthDate.Year;

        if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
        {
            age--;
            return age;
        }

       else return age;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime BirthDate = DateTime.Parse(DateOfBirthTB.Text);
        //AgeCalc(BirthDate);
        if (IsLegalAge(BirthDate) >= 16)
        {
            try
            {
                string Path = "~/pic/" + IdTB.Text; // הניתוב לתמונה ביחד עם התז הייחודי
                localhost.WS NewEmployee = new localhost.WS();
                NewEmployee.InsertEmployeeService(NameTB.Text, int.Parse(IdTB.Text), AddressTB.Text, DateTime.Parse(DateOfBirthTB.Text), PhoneNumberTB.Text, DateTime.UtcNow.Date, Path);
                FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/pic/" + IdTB.Text); // שמירת תמונה בשם של התז כדי למנוע כפילויות
                Response.Redirect("EmployeesMain.aspx");
                Response.Write("<script>alert('ההרשמה נקלטה במערכת');</script>");
            }
            catch
            {
                Response.Write("<script>alert('כבר קיים עובד עם נתונים יחודיים אלו');</script>");
            }
        }

        else Response.Write("<script>alert('תאריך לידה לא חוקי');</script>");
        
    }
}