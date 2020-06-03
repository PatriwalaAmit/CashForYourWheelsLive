using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for UserSession
/// </summary>
public class UserSession
{
	public UserSession()
	{
		
	}

    private int _UserID;

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    private int _UserTypeID;

    public int UserTypeID
    {
        get { return _UserTypeID; }
        set { _UserTypeID = value; }
    }

    private string _Email;

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private string _Password;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    private string _FirstName;

    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }
    private string _LastName;

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }
	
}
