using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class UserControls_TitleStrip : System.Web.UI.UserControl
{
    #region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerSessions"] != null)
            {
                HLHome.Text = "Member Profile";
                HyperLink1.Text = "Logout";
                img1.ImageUrl = "~/Images/member-ico.gif";
                Image1.ImageUrl = "~/Images/logoutsmall.gif";
            }
            else
            {
                HLHome.Text = "Member Login";
                HyperLink1.Text = "Register";
                img1.ImageUrl = "~/Images/icon-member-login.gif";
                Image1.ImageUrl = "~/Images/icon-register.gif";
            }
            
        }
    }
    #endregion

    #region Other methods
    //private string CheckWishList(List<ProductInfo> check)
    //{
    //    string _strId = "", _strQty = "";
    //    for (int i = 0; i < check.Count; i++)
    //    {
    //        _strId = _strId + "," + Convert.ToString(check[i].ProductId);
    //        _strQty = _strQty + "," + Convert.ToString(check[i].Qty);
    //    }
    //    if (!string.IsNullOrEmpty(_strId))
    //    {
    //        return _strId.Substring(1) + ">" + _strQty.Substring(1);
    //    }
    //    else
    //    {
    //        return "0";
    //    }
    //}
    #endregion

    #region Link Button Click


    protected void HLHome_Click(object sender, EventArgs e)
    {
        if (HLHome.Text == "Member Login")
        {
            Response.Redirect("~/User/Login.aspx");
        }
        else
        {
            Response.Redirect("~/User/Members.aspx");
        }
    }
    protected void HyperLink1_Click(object sender, EventArgs e)
    {
        if (HyperLink1.Text == "Register")
        {
            Response.Redirect("~/Registration.aspx");
        }
        else
        {
            Session["CustomerSessions"] = null;
            Session.Remove("CustomerSessions");
            Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=01,top=01,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
            Response.Write("<script language=javascript>wnd.close();</script>");
            Response.Write("<script language=javascript>window.open('Login.aspx','_parent',replace=true);</script>");
        }
    }
    protected void btnWishList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/WishList.aspx");
    }
    protected void btnShoppingCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/ShoppingCart.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/Checkout.aspx");
    }
    #endregion
    protected void lnksitemap_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/Sitemap.aspx");
    }
}
