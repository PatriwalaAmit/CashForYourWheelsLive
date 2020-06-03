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
/// Summary description for CustomerSessions
/// </summary>
public class CustomerSessions
{
    public CustomerSessions()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int _CustomerId=0;
    public int CustomerId
    {
        get { return _CustomerId; }
        set { _CustomerId = value; }
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

    private char _Sex;
    public char Sex
    {
        get { return _Sex; }
        set { _Sex = value; }
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

    private string _Address1;
    public string Address1
    {
        get { return _Address1; }
        set { _Address1 = value; }
    }

    private string _Address2;
    public string Address2
    {
        get { return _Address2; }
        set { _Address2 = value; }
    }

    private int _CityId;
    public int CityId
    {
        get { return _CityId; }
        set { _CityId = value; }
    }

    private string _City;
    public string City
    {
        get { return _City; }
        set { _City = value; }
    }

    private int _StateId;
    public int StateId
    {
        get { return _StateId; }
        set { _StateId = value; }
    }

    private string _State;
    public string State
    {
        get { return _State; }
        set { _State = value; }
    }

    private int _CountryId;
    public int CountryId
    {
        get { return _CountryId; }
        set { _CountryId = value; }
    }

    private string _Country;
    public string Country
    {
        get { return _Country; }
        set { _Country = value; }
    }

    private string _ZipCode;
    public string ZipCode
    {
        get { return _ZipCode; }
        set { _ZipCode = value; }
    }

    private string _PhoneNo;
    public string PhoneNo
    {
        get { return _PhoneNo; }
        set { _PhoneNo = value; }
    }

    private string _BusinessName;

    public string BusinessName
    {
        get { return _BusinessName; }
        set { _BusinessName = value; }
    }

    private string _BFax;

    public string BFax
    {
        get { return _BFax; }
        set { _BFax = value; }
    }

    private string _BContactPerson;

    public string BContactPerson
    {
        get { return _BContactPerson; }
        set { _BContactPerson = value; }
    }
	


}
