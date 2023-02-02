using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;




// מחלקה עובדים
public class Employee
{
    protected OleDbConnection myConnection;
    public Employee()
    {
        string connectionString = connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
    }


    // קבלת עובדים
    public DataSet GetAllEmployees()
    {
        OleDbCommand myCommand = new OleDbCommand("AllEmployees", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCommand;
        DataSet dataset = new DataSet();
        try
        {
            adapter.Fill(dataset, "employees");
            dataset.Tables["employees"].PrimaryKey = new DataColumn[] { dataset.Tables["employees"].Columns["Id"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dataset;
    }


    // קבלת מידע על עובד
    public DataSet GetEmployeeData(int Id)
    {
        OleDbCommand myCommand = new OleDbCommand("EmployeeData", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;


        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCommand;
        DataSet dataset = new DataSet();
        try
        {
            adapter.Fill(dataset, "employees");
            dataset.Tables["employees"].PrimaryKey = new DataColumn[] { dataset.Tables["employees"].Columns["Id"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dataset;
    }


    // עדכון עובד פרטים הכרחיים
    public void UpdateEmployeeNecessary(string FullName, string Address, string PhoneNumber, int Id)
    {
        OleDbCommand myCommand = new OleDbCommand("UpdateEmployeeNecessary", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        OleDbParameter NameParam = myCommand.Parameters.Add("@FullName", OleDbType.BSTR);
        NameParam.Value = FullName;

        OleDbParameter AddressParam = myCommand.Parameters.Add("@Address", OleDbType.BSTR);
        AddressParam.Value = Address;

        OleDbParameter PhoneNumberParam = myCommand.Parameters.Add("@PhoneNumber", OleDbType.BSTR);
        PhoneNumberParam.Value = PhoneNumber;

        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            myConnection.Close();
        }
    }

    // הוספת עובד
    public void InsertEmployee(string FullName, int Id, string Address, DateTime DateOfBirth, string PhoneNumber, DateTime firstDay, string Img)
    {

        OleDbCommand myCommand = new OleDbCommand("InsertEmployee", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        OleDbParameter NameParam = myCommand.Parameters.Add("@FullName", OleDbType.BSTR);
        NameParam.Value = FullName;

        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        OleDbParameter AddressParam = myCommand.Parameters.Add("@Address", OleDbType.BSTR);
        AddressParam.Value = Address;

        OleDbParameter DateOfBirthParam = myCommand.Parameters.Add("@DateOfBirth", OleDbType.Date);
        DateOfBirthParam.Value = DateOfBirth;

        OleDbParameter PhoneNumberParam = myCommand.Parameters.Add("@PhoneNumber", OleDbType.BSTR);
        PhoneNumberParam.Value = PhoneNumber;

        OleDbParameter firstDayParam = myCommand.Parameters.Add("@firstDay", OleDbType.Date);
        firstDayParam.Value = firstDay;

        OleDbParameter ImgParam = myCommand.Parameters.Add("@firstDay", OleDbType.BSTR);
        ImgParam.Value = Img;

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }



    // מחיקת עובד
    
    public void DeleteEmployee(int Id)
    {

        OleDbCommand myCommand = new OleDbCommand("DeleteEmployee", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            myConnection.Close();
        }
    }

}




// ימי העדרות


public class DaysAway
{
    protected OleDbConnection myConnection;
    public DaysAway()
    {
        string connectionString = connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
    }


    // קבלת ימי העדרות לפי עובד
    public DataSet GetDaysAway(int Id) 
    {
        OleDbCommand myCommand = new OleDbCommand("EmployeeDates", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = myCommand;
        DataSet dataset = new DataSet();

        try
        {
            adapter.Fill(dataset, "DaysAway");
            dataset.Tables["DaysAway"].PrimaryKey = new DataColumn[] { dataset.Tables["DaysAway"].Columns["Id"] };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dataset;
    }



    // קבלת  כמות ימי העדרות לפי עובד
    public int GetCountOfDaysAway(int Id)
    {
        OleDbCommand myCommand = new OleDbCommand("VacationDaysCounter", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        try
        {
            myConnection.Open();
            int rowCount = (int)myCommand.ExecuteScalar();
            return rowCount;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }


    // הוספת יום העדרות
    public void InsertDayAway(int Id, DateTime DayAway, string kind)
    {

        OleDbCommand myCommand = new OleDbCommand("InsertDayAway", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        OleDbParameter DayAwayParam = myCommand.Parameters.Add("@DayAway", OleDbType.Date);
        DayAwayParam.Value = DayAway;

        OleDbParameter kindParam = myCommand.Parameters.Add("@kind", OleDbType.BSTR);
        kindParam.Value = kind;

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    // מחיקת יום חופש
    public void DeleteVacationDay(int Id, DateTime DateAway)
    {

        OleDbCommand myCommand = new OleDbCommand("DeleteVacationDay", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        OleDbParameter IdParam = myCommand.Parameters.Add("@Id", OleDbType.Integer);
        IdParam.Value = Id;

        OleDbParameter DateParam = myCommand.Parameters.Add("@DateAway", OleDbType.Date);
        DateParam.Value = DateAway;

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            myConnection.Close();
        }
    }
}


