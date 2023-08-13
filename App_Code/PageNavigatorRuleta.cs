using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

public class PageNavigatorRuleta : System.Web.UI.Page
{
    private string _keysCC = "vGRIpbaEApE9aKxsUgyxeES2DoAhxtnR2vbmSypNoZU=";
    private string _idUsuarioSesion;
    private string _idEmpresaSesion;
    private string _idCampania;
    public string keysCC
    {
        get { return _keysCC; }
    }
    public string idUsuarioSesion
    {
        get { return _idUsuarioSesion; }
    }
    public string idEmpresaSesion
    {
        get { return _idEmpresaSesion; }
    }
    public string idCampania
    {
        get { return _idCampania; }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //_keysCC = Utilidad.validaCampo(Request.Params["key"], "str");
        Validacion _encript = new Validacion();
        string[] _desencriptar = { };
        if (keysCC == "")
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>window.location.href='/Opps?err=99'</script>");
        }
        else
        {
            try
            {
                _desencriptar = _encript.DesencryptarText(keysCC).Split('|');
                _idCampania = _desencriptar[0].Split('=')[1];
                _idEmpresaSesion = _desencriptar[1].Split('=')[1];
                _idUsuarioSesion = _desencriptar[2].Split('=')[1];
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script type='text/javascript'>window.location.href='/Opps?err=98'</script>");
            }
        }
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //Sobreescribe validación de form
    }
    public void logError(Exception ex, string funcion, string parametros)
    {

    }
}