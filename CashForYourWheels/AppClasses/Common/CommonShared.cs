using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TSHAK.Components;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for CommonShared
/// </summary>
public static class CommonShared
{
    #region Variable

    public static string QueryStringVariable = "Data";

    #endregion

    #region Public Function

    public static string EncryptQueryString(Hashtable myHt)
    {
        try
        {
            SecureQueryString qs = new SecureQueryString();

            foreach (DictionaryEntry myKey in myHt)
            {
                string strKey;
                string strValue;
                strKey = myKey.Key.ToString();
                strValue = myKey.Value.ToString();
                qs[strKey] = strValue;
            }
            return qs.ToString();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static string DecryptQueryString(string paramName, string strEncryptedString)
    {
        try
        {
            if (!string.IsNullOrEmpty(strEncryptedString))
            {
                SecureQueryString qs = new SecureQueryString(strEncryptedString);
                return qs[paramName];
            }
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }


    /// <summary>
    /// Encrypt the String
    /// </summary>
    /// <param name="strEncrypted"></param>
    /// <returns>return the encrypted string</returns>
    public static string EnryptString(string strEncrypted)
    {
        try
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string enryptString = Convert.ToBase64String(b);
            return enryptString;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public static string DecryptString(string encrString)
    {
        try
        {
            byte[] b = Convert.FromBase64String(encrString);
            string decryptString = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decryptString;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static string GetUniqueKey()
    {
        int maxSize = 8;
        char[] chars = new char[62];
        string a;

        a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        chars = a.ToCharArray();

        int size = maxSize;
        byte[] data = new byte[1];

        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

        crypto.GetNonZeroBytes(data);
        size = maxSize;
        data = new byte[size];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(size);

        foreach (byte b in data)
        {
            //result.Append(chars1)>); 
            result.Append(chars[b % (chars.Length - 1)]);
        }
        return result.ToString();
    }
    #endregion

}
