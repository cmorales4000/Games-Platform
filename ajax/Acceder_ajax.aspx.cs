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

public partial class _Acceder_ajax : Autenticacion
{
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //Sobreescribe validación de form
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string ndoc = Utilidad.validaCampo(Request.Params["ndoc"], "str");
            string pwd = Utilidad.validaCampo(Request.Params["pwd"], "str");
            string recordar = Utilidad.validaCampo(Request.Params["recordar"], "int");
            string msgError = "";
            string urlPagina = Utilidad.validaCampo(Request.Params["url"], "str");
            if (urlPagina.LastIndexOf(",") != -1)
            {
                urlPagina = urlPagina.Substring(0, urlPagina.LastIndexOf(","));
                urlPagina = (urlPagina.LastIndexOf("/Acceder") != -1 ? "" : urlPagina);
            }
            string varMensaje = "";

            Validacion _encript = new Validacion();
            //string pe = _encript.DesencryptarText("");
            //string pe = _encript.EncryptarText("");

            if (ndoc == "")
            {
                msgError = "Debe ingresar un número de documento.";
            }
            if (pwd == "")
            {
                msgError = "Debe ingresar una contraseña.";
            }
            //if (pin == "")
            //{
            //    msgError = "Debe ingresar un pin.";
            //}
            if (msgError == "")
            {   msgError = AuthenticateCont(ndoc, pwd, (recordar == "1" ? true : false));
                if (msgError == "")
                {
                    urlPagina = (urlPagina != "" ? urlPagina : Session["urlPagInicio"].ToString());
                }
            }
            Response.Write("{\"rta\":\"" + msgError + "\",\"url\":\"" + urlPagina + "\"}");
        }
        catch (Exception ex)
        {
        }
    }
}