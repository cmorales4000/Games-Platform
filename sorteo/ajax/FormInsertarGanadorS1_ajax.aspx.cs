using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_FormInsertarGanadorS1_ajax : PageNavigatorRuleta
{
    private List<DataTable> _lstDt;
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //Sobreescribe validación de form
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            _lstDt = Juegos.checkJuegos("M4", Utilidad.validaCampo(Request.Params["conId"].ToString(), "int"), Utilidad.validaCampo(Request.Params["camId"].ToString(), "int"), Utilidad.validaCampo(Request.Params["bolConsecutivo"].ToString(), "int"), "Sorteo", "", "", "", "", "", "", "", "", "");
            //ConsultasBasicas.actualizarBasico2("M4", Utilidad.validaCampo(Request.Params["conId"].ToString(),"int"), Utilidad.validaCampo(Request.Params["camId"].ToString(), "int"), Utilidad.validaCampo(Request.Params["bolConsecutivo"].ToString(), "int"), "Sorteo Tesoro", "", "", "", "", "", "", "", "", "");
        }
        catch(Exception ex)
        {
            logError(ex, "Page_Load", "");
        }
    }
}