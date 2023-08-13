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

public partial class _Acceder : Autenticacion
{
    private string host = "";
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //Sobreescribe validación de form
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Validacion _encript = new Validacion();
            //Validamos si ya hay una sesion abierta
            if (!IsPostBack)
            {
                if (Session["conId" + host] != null)
                {
                    Response.Redirect(this.ResolveClientUrl("~") + Session["urlPagInicio" + host], false);
                }
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    System.Web.HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    try
                    {
                        if (ticket.Expiration.CompareTo(DateTime.Now) >= 0)
                        {
                            //Relogeamos
                            //Validacion _encript = new Validacion();
                            string[] parametros = _encript.DesencryptarText(ticket.UserData).ToString().Split('|');
                            if (AuthenticateCont(parametros[0], parametros[1], ticket.IsPersistent) == "")
                            {
                                Response.Redirect(this.ResolveClientUrl("~") + Session["urlPagInicio" + host], false);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }

            string _url = Utilidad.validaCampo(Request.Params["url"], "str");
            if (_url.LastIndexOf(",") != -1)
            {
                _url = _url.Substring(0, _url.LastIndexOf(","));
            }
            url.Value = _url;
        }
        catch (Exception ex)
        {

        }
    }
}