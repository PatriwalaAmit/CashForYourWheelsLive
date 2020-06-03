using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using log4net;

public partial class Global : System.Web.HttpApplication
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    void Application_Start(object sender, EventArgs e)
    {
        log4net.Config.XmlConfigurator.Configure();
        RouteConfig.RegisterRoutes(RouteTable.Routes);
    }


    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        var error = Server.GetLastError().GetBaseException();
        log.Error(error);
        Response.Redirect("~/Errors.aspx", false);
    }

    void Session_Start(object sender, EventArgs e)
    {


    }

    void Session_End(object sender, EventArgs e)
    {

    }
}