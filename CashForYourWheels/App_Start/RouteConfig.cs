using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

public static class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        var settings = new FriendlyUrlSettings();
        settings.AutoRedirectMode = RedirectMode.Permanent;
        routes.EnableFriendlyUrls(settings);

        routes.MapPageRoute("Motorbike", "Motorbike-Selection-1", "~/Motorbike.aspx");
        routes.MapPageRoute("Leisure", "Leisure-Selection-1", "~/Leisure.aspx");
        routes.MapPageRoute("Car", "Car-Selection", "~/Car.aspx");
    }
}