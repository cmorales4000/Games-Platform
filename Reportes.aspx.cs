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

public partial class _Reportes : PageSession
{
    private List<DataTable> _lstDt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string sPorVisitar = "", sVisitados = "", sLogo = "";
            _lstDt = Juegos.checkJuegos("N2", conId, "", "", "", "", "", "", "", "", "", "", "", "");
            if (_lstDt != null)
            {
                if (_lstDt.Count > 1)
                {
                    //Por Visitar
                    if (_lstDt[0].Rows.Count > 0)
                    {
                        sPorVisitar += "<div class=\"row\">";
                        foreach(DataRow dr in _lstDt[0].Rows)
                        {
                            sLogo = "/assets/images/logos/minivivo.png";
                            sPorVisitar += "<div class=\"col-md-3 col-sm-4 col-xs-6 text-center\">";
                            sPorVisitar += "<div style=\"min-height:200px;\">";
                            sPorVisitar += "<img src=\"" + sLogo + "\" class=\"img-responsive\" style=\"height:100px;width:165px;border:1px solid #3b3b3b;padding:5px;border-radius: 8px 8px 8px 8px;-moz-border-radius: 8px 8px 8px 8px;-webkit-border-radius: 8px 8px 8px 8px;\" />";
                            sPorVisitar += dr["locNom"].ToString();
                            sPorVisitar += "</div>";
                            sPorVisitar += "</div>";
                        }
                        sPorVisitar += "</div>";
                    }
                    else
                    {
                        //EVENTO COMPLETADO
                        divfin.Visible = true;
                    }
                    //Visitados
                    if (_lstDt[1].Rows.Count > 0)
                    {
                        sVisitados += "<div class=\"row\">";
                        foreach (DataRow dr in _lstDt[1].Rows)
                        {
                            
                            sLogo = "/assets/images/logos/miniderrotado.png";
                            sVisitados += "<div class=\"col-md-3 col-sm-4 col-xs-6 text-center\">";
                            sVisitados += "<div style=\"min-height:200px;\">";
                            sVisitados += "<img src=\"" + sLogo + "\" class=\"img-responsive\" style=\"height:100px;width:165px;border:1px solid #3b3b3b;padding:5px;border-radius: 8px 8px 8px 8px;-moz-border-radius: 8px 8px 8px 8px;-webkit-border-radius: 8px 8px 8px 8px;\" />";
                            sVisitados += dr["locNom"].ToString();
                            sVisitados += "</div>";
                            sVisitados += "</div>";
                        }
                        sVisitados += "</div>";
                    }

                }
            }
            porVisitar.InnerHtml = sPorVisitar;
            visitados.InnerHtml = sVisitados;
        }
        catch (Exception ex)
        {

        }
    }
}