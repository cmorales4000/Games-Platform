using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;

public class PageSession : Autenticacion
{
    private string _conId;
    private string _nomUsu;
    private string _apeUsu;
    private string _nomApeUsu;
    private string _conEmail;
    private string _conNdoc;
    private string hostSesion = "";
    public string conId { get { return _conId; } }
    public string nomUsu { get { return _nomUsu; } }
    private string apeUsu { get { return _apeUsu; } }  
    private string nomApeUsu { get { return _nomApeUsu; } }
    private string conEmail { get { return _conEmail; } }
    private string conNdoc { get { return _conNdoc; } }
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //Sobreescribe validación de form
    }

    public Boolean isSession()
    {
        Boolean sessionActiva = true;

        //valida si la variable session es nula o vacia informe que se ha cerrado
        if (Equals(Session["conId" + hostSesion], null) || Equals(Session["conId" + hostSesion], ""))
        {
            sessionActiva = false;
        }
        return sessionActiva;
    }

    protected void redirectLogin()
    {
        //HttpContext.Current.Response.Write("<script type='text/javascript'>window.location.href='/Acceder?url=" + Server.UrlEncode(HttpContext.Current.Request.Url.AbsolutePath) + "'</script>");
        HttpContext.Current.Response.Redirect(this.ResolveClientUrl("~") + "Acceder?url=" + Server.UrlEncode(HttpContext.Current.Request.Url.AbsolutePath), true);
    }

    protected void loadVariables()
    {
        //Seteamos las variables de session
        _conId = Session["conId" + hostSesion].ToString();
        _nomUsu = Session["nomUsu" + hostSesion].ToString();
        _apeUsu = Session["apeUsu" + hostSesion].ToString();
        _nomApeUsu = Session["nomApeUsu" + hostSesion].ToString();
        _conNdoc = Session["conNdoc" + hostSesion].ToString();
        _conEmail = Session["conEmail" + hostSesion].ToString();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (!isSession())
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket.Expiration.CompareTo(DateTime.Now) >= 0)
                {
                    //Relogeamos
                    Validacion _encript = new Validacion();
                    string[] parametros = _encript.DesencryptarText(ticket.UserData).ToString().Split('|');
                    if (AuthenticateCont(parametros[0], parametros[1], ticket.IsPersistent) != "")
                    {
                        redirectLogin();
                    }
                    else
                    {
                        loadVariables();
                    }
                }
                else
                {
                    redirectLogin();
                }
            }
            else
            {
                redirectLogin();
            }
        }
        else
        {
            loadVariables();
        }

    }
}