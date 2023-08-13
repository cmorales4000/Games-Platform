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
using System.Data;

public partial class _sorteo1 : System.Web.UI.Page
{
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //Sobreescribe validación de form
    }
    private List<DataTable> _lstDt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //_lstDt = ConsultasBasicas.getConsultasBasicas2("M4", "S1", "", "", "", "");
            string camId = "19"; //ESCRIBIR NUMERO DE LA CAMPAÑA DONDE SE ALMACENAN LOS FINALISTAS
            _lstDt = Juegos.checkJuegos("M8", "S1", camId, "", "", "", "", "", "", "", "", "", "", "");
            string sListaPosibles = "";
            if (_lstDt != null)
            {
                if (_lstDt.Count > 0)
                {
                    if (_lstDt[0].Rows.Count > 0)
                    {
                        int contador = 0;
                        sListaPosibles += "<div id=\"ganador" + contador.ToString() + "\" data-id=\"" + 0 + "\" data-bol=\"" + 0
                            + "\"> JUEGA </br> VUELVE A GIRAR </div>";
                        foreach (DataRow dr in _lstDt[0].Rows)
                        {
                            contador++;
                            sListaPosibles += "<div id=\"ganador" + contador.ToString() + "\" data-id=\"" + dr["conId"].ToString() + "\" data-cam=\"" + camId + "\" data-bol=\"" + dr["bolConsecutivo"].ToString() + "\"> Boleta: " + dr["bolConsecutivo"].ToString() 
                                + " // CC - " + string.Concat(dr["conNdoc"].ToString().Reverse().Skip(4).Reverse()) + "****</br>" + dr["conNomApe"].ToString() +  "</div>";
                            //+"</br>" + dr["conNomApe"].ToString() + "</br> CC - " + string.Concat(dr["conNdoc"].ToString().Reverse().Skip(4).Reverse()) + "****</div>";
                            
                        }
                    }
                }
            }
            lstGanadores.InnerHtml = sListaPosibles;
        }
        catch (Exception ex)
        {

        }
    }
}