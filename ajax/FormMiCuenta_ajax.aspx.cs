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

public partial class _Ajax_FormMiCuenta_ajax : PageSession
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string accionExec = Utilidad.validaCampo(Request.Params["accion"], "int");

            string _nombre = Utilidad.validaCampo(Request.Params["txtNombre"], "str");
            string _apellido = Utilidad.validaCampo(Request.Params["txtApellido"], "str");
            string _email = Utilidad.validaCampo(Request.Params["txtEmail"], "str");
            string _celular = Utilidad.validaCampo(Request.Params["txtCelular"], "str");

            switch (accionExec)
            {
                case "0":
                    tblDataContacto.Visible = true;
                    tdNdoc.InnerText = Session["conNdoc"].ToString();
                    tdNom.InnerText = Session["nomUsu"].ToString();
                    tdApe.InnerText = Session["apeUsu"].ToString();
                    tdEmail.InnerText = Session["conEmail"].ToString();
                    tdCelular.InnerText = Session["conCel"].ToString();
                    break;
                case "1":
                    dvFrmMiCuenta.Visible = true;
                    accion.Value = "2";
                    txtIdentificacion.Text = Session["conNdoc"].ToString();
                    txtNombre.Text = Session["nomUsu"].ToString();
                    txtApellido.Text = Session["apeUsu"].ToString();
                    txtEmail.Text = Session["conEmail"].ToString();
                    txtCelular.Text = Session["conCel"].ToString();
                    break;
                case "2":
                    Session["nomUsu"] = _nombre;
                    Session["apeUsu"] = _apellido;
                    Session["conEmail"] = _email;
                    Session["conCel"] = _celular;
                    Juegos.checkJuegos("M2", Session["conId"].ToString(), _nombre, _apellido, _email, _celular, "", "", "", "", "", "", "", "");
                    Response.Write("<script language=\"javascript\">$(function(){cerrarDialogo('dvFrmMiCuenta');loadData();})</script>");
                    //Actualizamos las variables de sesion
                    break;
            }
        }
        catch (Exception ex)
        {
        }
    }
}