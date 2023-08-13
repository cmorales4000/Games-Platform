using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;
using System.Runtime.InteropServices;
using System.Web.Security;

public partial class _Logout : System.Web.UI.Page
{
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //Sobreescribe validación de form
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string host = Request.Url.Host + (Request.Url.Port != 80 ? ":" + Request.Url.Port.ToString() : "");

            Session.Abandon();
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            authCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(authCookie);

            Response.Redirect(Page.ResolveUrl("~") + "Acceder");
        }
        catch (Exception ex)
        {

        }
    }
}