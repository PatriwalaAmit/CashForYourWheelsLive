using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections;

/// <summary>
/// Summary description for URLRewrites
/// </summary>
public class URLRewrites : System.Web.IHttpModule
{
    public URLRewrites()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region IHttpModule Members

    public void Dispose()
    {
        //throw new Exception("The method or operation is not implemented.");
    }

    public void Init(HttpApplication context)
    {
        context.BeginRequest += new System.EventHandler(Rewrite_BeginRequest);
    }

    public void Rewrite_BeginRequest(object sender, System.EventArgs args)
    {
        string strURI = HttpContext.Current.Request.Url.ToString();
        string strPath = HttpContext.Current.Request.Url.AbsolutePath;

        #region URL Rewriting For Large Images
        if (strPath.Contains("/LargeImage.aspx"))
        {
            string _QueryString = CommonShared.DecryptQueryString("id", HttpContext.Current.Request.QueryString["data"]);
            if (!string.IsNullOrEmpty(_QueryString))
            {
                Hashtable h1 = new Hashtable();
                h1.Add("id", _QueryString);

                HttpContext.Current.RewritePath("~/User/LargeImage.aspx?data=" + CommonShared.EncryptQueryString(h1), false);
            }
            else
            {
                Hashtable h1 = new Hashtable();
                h1.Add("id", _QueryString);

                HttpContext.Current.RewritePath("~/User/LargeImage.aspx?data=" + CommonShared.EncryptQueryString(h1), false);
            }
        }
        #endregion

        #region URL rewriting for Tell A Frnd list
        else if (strPath.Contains("/TellAFriend.aspx"))
        {
            HttpContext.Current.RewritePath("~/User/Email.aspx", false);
        }
        #endregion

        #region URL Rewriting for login Page
        else if (strPath.Contains("/Login.aspx"))
        {
            string _query = Convert.ToString(HttpContext.Current.Request.QueryString);
            HttpContext.Current.RewritePath("~/User/Login.aspx?" + _query, false);
        }
        #endregion

        #region URL Rewriting For Product Promotions
        else if (strPath.Contains("/Best_Features.aspx"))
        {
            HttpContext.Current.RewritePath("~/User/BestFeatures.aspx?Key=Best", false);
        }
        else if (strPath.Contains("/Monthly_Special.aspx"))
        {
            HttpContext.Current.RewritePath("~/User/BestFeatures.aspx?Key=Month", false);
        }
        else if (strPath.Contains("/New_Year_Special.aspx"))
        {
            HttpContext.Current.RewritePath("~/User/BestFeatures.aspx?Key=Year", false);
        }
        else if (strPath.Contains("/Hot_Items.aspx"))
        {
            HttpContext.Current.RewritePath("~/User/BestFeatures.aspx?Key=Hot", false);
        }
        #endregion

        #region URL Rewriting For Others
        else
        {
            #region URL Rewriting For Category List
            if (strPath.Contains("/Category/"))
            {
                //string _QueryString = strPath.Replace("/Category/", string.Empty);
                //string _QueryString = strPath.IndexOf("/Category/");

                string _QueryString = strPath.Substring(strPath.IndexOf("/Category/")).Replace("/Category/", string.Empty);

                if (!string.IsNullOrEmpty(_QueryString))
                {
                    if (_QueryString.Contains(".aspx"))
                    {
                        string _PostedURL = _QueryString;
                        string[] redirect = _QueryString.Split('/');
                        _QueryString = redirect[redirect.Length - 1];

                        DataTable table = URLCheck.CheckForCategory(_QueryString.Replace("_", " ").Replace(".aspx", string.Empty));
                        if (table.Rows.Count > 0)
                        {
                            Hashtable h1 = new Hashtable();
                            h1.Add("id", table.Rows[0]["CategoryIdName"]);
                            HttpContext.Current.RewritePath("~/User/CategoryList.aspx?data=" + CommonShared.EncryptQueryString(h1) + "&PostURL=" + _PostedURL, false);
                        }
                        else
                        {
                            Hashtable h1 = new Hashtable();
                            h1.Add("id", 0);
                            HttpContext.Current.RewritePath("~/User/CategoryList.aspx?data=" + CommonShared.EncryptQueryString(h1), false);
                        }
                    }
                }
            }
            #endregion

            #region URL Rewriting Products
            if (strPath.Contains("/Products/"))
            {
                //string _QueryString = strPath.Replace("/ECommerce/Products/", string.Empty);

                string _QueryString = strPath.Substring(strPath.IndexOf("/Products/")).Replace("/Products/", string.Empty);

                if (!string.IsNullOrEmpty(_QueryString))
                {
                    if (_QueryString.Contains(".aspx"))
                    {
                        string[] redirect = _QueryString.Split('/');
                        _QueryString = redirect[redirect.Length - 1];

                        DataTable table = URLCheck.CheckForCategory(_QueryString.Replace("_", " ").Replace(".aspx", string.Empty));
                        if (table.Rows.Count > 0)
                        {
                            Hashtable h1 = new Hashtable();
                            h1.Add("id", table.Rows[0]["CategoryIdName"]);
                            HttpContext.Current.RewritePath("~/User/ProductList.aspx?data=" + CommonShared.EncryptQueryString(h1), false);
                        }
                        else
                        {
                            Hashtable h1 = new Hashtable();
                            h1.Add("id", 0);
                            HttpContext.Current.RewritePath("~/User/ProductList.aspx?data=" + CommonShared.EncryptQueryString(h1), false);
                        }
                    }
                }
            }
            #endregion

            #region URL Rewriting Product Details
            if (strPath.Contains("/ProductDetails/"))
            {
                //string _QueryString = strPath.Replace("/ECommerce/ProductDetails/", string.Empty);

                string _QueryString = strPath.Substring(strPath.IndexOf("/ProductDetails/")).Replace("/ProductDetails/", string.Empty);

                if (!string.IsNullOrEmpty(_QueryString))
                {
                    if (_QueryString.Contains(".aspx"))
                    {
                        string[] redirect = _QueryString.Split('/');
                        _QueryString = redirect[redirect.Length - 1];

                        DataTable table = URLCheck.CheckForProductList(_QueryString.Replace("_", " ").Replace(".aspx", string.Empty));
                        if (table.Rows.Count > 0)
                        {
                            Hashtable h1 = new Hashtable();
                            h1.Add("id", table.Rows[0]["ProductIdName"]);
                            HttpContext.Current.RewritePath("~/User/ProductDetails.aspx?data=" + CommonShared.EncryptQueryString(h1), false);
                        }
                        else
                        {
                            Hashtable h1 = new Hashtable();
                            h1.Add("id", 0);                            
                            HttpContext.Current.RewritePath("~/User/ProductDetails.aspx?data=" + CommonShared.EncryptQueryString(h1), false);
                        }
                    }
                }
            }
            #endregion
        }
        #endregion
    }
    #endregion
}
