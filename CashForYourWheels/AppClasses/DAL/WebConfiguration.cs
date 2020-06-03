using System;
using System.Configuration;

/// <summary>
/// Repository for configuration settings
/// </summary>
public static class WebConfiguration
{
    // Caches the connection string
    private readonly static string dbConnectionString;
    // Caches the data provider name 
    private readonly static string dbProviderName;


    // Initialize various properties in the constructor
    static WebConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName;
    }
    
    // Returns the connection string for the database
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    // Returns the data provider name
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }
}
