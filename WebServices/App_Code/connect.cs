using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for connect
/// </summary>
public class connect
{
	public connect()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    const string FILE_NAME = "Dvir'sProject.mdb";
    public static string getConnectionString()
    {
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + FILE_NAME);
        string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; data source=" + location;
        return ConnectionString;
    }

}