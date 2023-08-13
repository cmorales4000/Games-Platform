using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
//using RestSharp;

public class Autenticacion : System.Web.UI.Page
{
    private Validacion _encript = new Validacion();

    public Autenticacion()
    {
    }

    public void CreateAuthCookie(string ndoc, string pws, bool remenber)
    {

        //Create the cookie that contains the forms authentication ticket
        //System.Web.HttpCookie authCookie = FormsAuthentication.GetAuthCookie(_encript.EncryptarText(email), remenber);
        System.Web.HttpCookie authCookie = FormsAuthentication.GetAuthCookie(_encript.EncryptarText(ndoc), remenber);
        //Get the FormsAuthenticationTicket out of the encrypted cookie
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
        //Create a new FormsAuthenticationTicket that includes our custom User Data
        FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, _encript.EncryptarText(ndoc + "|" + pws));
        //Update the authCookie's Value to use the encrypted version of newTicket
        authCookie.Value = FormsAuthentication.Encrypt(newTicket);
        //Manually add the authCookie to the Cookies collection
        HttpContext.Current.Response.Cookies.Add(authCookie);
    }
    public string AuthenticateCont(string identificacion, string pws, bool remenber)
    {
        string msgRta = "";

        string pwse = _encript.EncryptarText(pws);
        List<DataTable> lstDt = Seguridad.iniciarSessionCont(identificacion, pws, "", "");
        if (lstDt != null)
        {
            if (lstDt.Count > 1)
            {
                if (lstDt[lstDt.Count - 1].Rows[0]["@msgRta"].ToString() != "OK")
                {
                    msgRta = lstDt[lstDt.Count - 1].Rows[0]["@msgRta"].ToString();
                }
                else
                {
                    string host = "";

                    Session["conId" + host] = lstDt[0].Rows[0]["conId"].ToString().ToUpper();
                    Session["nomUsu" + host] = lstDt[0].Rows[0]["conNom"].ToString();
                    Session["apeUsu" + host] = lstDt[0].Rows[0]["conApe"].ToString();
                    Session["nomApeUsu" + host] = lstDt[0].Rows[0]["conNom"].ToString() + " " + lstDt[0].Rows[0]["conApe"].ToString();
                    Session["conNdoc" + host] = identificacion;
                    Session["conEmail" + host] = lstDt[0].Rows[0]["conEmail"].ToString();
                    Session["conCel" + host] = lstDt[0].Rows[0]["conCel"].ToString();

                    Session["urlPagInicio" + host] = "/MiCuenta";
                    

                    if (remenber)
                    {
                        CreateAuthCookie(identificacion, pws, remenber);
                    }
                }
            }
        }
        return msgRta;
    }

}

public class Datum
{
    public string celular { get; set; }
    public int id_sms { get; set; }
}

public class ResponseItCLoud
{
    public List<Datum> data { get; set; }
    public string message { get; set; }
    public string status { get; set; }
}