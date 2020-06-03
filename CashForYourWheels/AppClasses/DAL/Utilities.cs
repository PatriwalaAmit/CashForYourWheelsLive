using System;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using log4net;


/// <summary>
/// Class contains miscellaneous functionality 
/// </summary>
public static class Utilities
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    static Utilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool RemoveFollowup(string emailAddress)
    {
        try
        {
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandText = "usp_removeVisitor";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlConn;

                sqlCmd.Parameters.Add("@emailAddress", SqlDbType.VarChar, 100).Value = emailAddress.Trim().ToLower();

                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
        catch (Exception ex)
        {
            log.Error("Error In RemoveFollowup", ex);
            return false;
        }

        return true;
    }

    public static bool LogVisitor(string title, string forename, string surname, string emailAddress, string registration, string valuation)
    {
        log.Debug("Values passed into LogVisitor: Title-" + title + " Forename-" + forename + " Surname-" + surname + " Emailaddress-" + emailAddress + " Reg-" + registration + " Val-" + valuation);

        try
        {
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandText = "usp_saveWebVisitor";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlConn;

                sqlCmd.Parameters.Add("@title", SqlDbType.VarChar, 10).Value = title;
                sqlCmd.Parameters.Add("@forename", SqlDbType.VarChar, 30).Value = forename;
                sqlCmd.Parameters.Add("@surname", SqlDbType.VarChar, 50).Value = surname;
                sqlCmd.Parameters.Add("@emailAddress", SqlDbType.VarChar, 100).Value = emailAddress.Trim().ToLower();
                sqlCmd.Parameters.Add("@reg", SqlDbType.VarChar, 12).Value = registration;
                sqlCmd.Parameters.Add("@val", SqlDbType.VarChar, 15).Value = valuation;

                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
        catch (Exception ex)
        {
            log.Error("Error In LogVisitor", ex);
            return false;
        }

        return true;
    }

    // Generic method for sending emails
    public static bool SendMail(string from, string to, string subject, string body, string cc)
    {       
        log.Debug("Into SendMail: " + from + " " + to);
        SmtpClient mailClient = new SmtpClient();
        mailClient.Host = ConfigurationManager.AppSettings["Host"].ToString();
        //mailClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["HostPort"].ToString());
        System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential(ConfigurationManager.AppSettings["HostUserName"].ToString(),
                                                ConfigurationManager.AppSettings["HostPassword"].ToString());

        // mailClient.UseDefaultCredentials = false;
        //mailClient.EnableSsl = true;
        mailClient.Credentials = credentials;

        // Create the mail message
        MailMessage mailMessage = new MailMessage(ConfigurationManager.AppSettings["HostUserName"].ToString(), to, subject, body);
        if (string.IsNullOrEmpty(cc) == false)
            mailMessage.CC.Add(cc);

        if (!subject.Contains("Value of"))
        {
            mailMessage.Bcc.Add("cash4yourwheels@gmail.com");
        }

        mailMessage.IsBodyHtml = true;

        // Send mail
        try
        {
            mailClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            log.Error(ex);
            return false;
        }
        finally
        {
            mailClient.Dispose();
        }
        log.Debug("Exiting SendEmail");
        return true;
    }

    //public static bool SendMail(string FromName, string from, string ToName, string to, string subject, string body, string LinkName)
    //{

    //    SmtpClient mailClient = new SmtpClient();
    //    mailClient.Host = ConfigurationManager.AppSettings["Host"].ToString();

    //    System.Net.NetworkCredential credentials =
    //        new System.Net.NetworkCredential(ConfigurationManager.AppSettings["HostUserName"].ToString(),
    //                                            ConfigurationManager.AppSettings["HostPassword"].ToString());

    //    mailClient.UseDefaultCredentials = false;
    //    mailClient.Credentials = credentials;

    //    // Create the mail message
    //    string _Subject = "You have been recommended a link by Your Friend," + FromName;
    //    string _Message = "Hi " + ToName + ",you have been recommended by Your Friend," + FromName + "\n" + body + "\nRegards,Team  Solutions";


    //    MailMessage mailMessage = new MailMessage(from, to, subject, _Message);


    //    mailMessage.IsBodyHtml = true;

    //    // Send mail

    //    try
    //    {
    //        mailClient.Send(mailMessage);
    //    }
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }
    //    return true;
    //}

}
