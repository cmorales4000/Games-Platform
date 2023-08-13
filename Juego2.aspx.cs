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
using RestSharp;
using System.Net;
using Newtonsoft.Json;

public partial class _Juego2 : PageSession
{
    private List<DataTable> _lstDt;
    private List<DataTable> _lstDt2;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string sBol = "";
            //Obtenemos el listado de piezas del rompecabezas que el usuario no haya escaneado
            _lstDt = Juegos.checkJuegos("M1J2", conId, "", "", "", "", "", "", "", "", "", "", "", "");
            if(_lstDt != null)
            {
                if (_lstDt.Count > 0)
                {
                    //ON/OFF SI HAY MULTIPLES INTENTOS
                    if (_lstDt[0].Rows.Count >= 0)
                    {
                        //ID CAMPAÑA DEL JUEGO ACTUAL 
                        string camId = "19";
                        _lstDt2 = Juegos.checkJuegos("M7", conId, camId, "", "", "", "", "", "", "", "", "", "", "");

                        if (_lstDt2[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in _lstDt2[0].Rows)
                            {
                                sBol = dr["bolConsecutivo"].ToString();

                                dvMsgRta.InnerHtml += "<h2>Tu código para el sorteo del tesoro es: " + sBol + "</h2>";
                            }
                            divfin.Visible = true;

                        }

                        string sImageMap = "";
                        foreach (DataRow dr in _lstDt[0].Rows)
                        {
                            sImageMap += dr["mapArea"].ToString();
                        }
                        imageMap.InnerHtml = sImageMap;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }


        //_lstDt = ConsultasBasicas.getConsultasBasicas2("M6", conId, "", "", "", "24");
        //if (_lstDt != null)
        //{
        //    if (_lstDt.Count > 0)
        //    {
        //        if (_lstDt[0].Rows.Count > 0)
        //        {
        //            DataRow ganador= _lstDt[0].Rows[0];
        //            //DataRow compraGanadora = _lstDt[1].Rows[0];
        //            DateTime _hora = DateTime.Now;

        //            string msgEmail = "";
        //            string nombreCampania = "Musical Tintal";
        //            string nombreTitulo = "Ruta de Experiencias - Evento musical de aniversario";
                    

        //            EnviarEmail _email = new EnviarEmail();

        //            msgEmail += "<table style=\"width:100%;\">";
        //            msgEmail += "<tr><td colspan=\"2\"><h1 style=\"text-align: center; line-height: 130%; \">" + nombreTitulo + "</h1></td></tr>";
        //            msgEmail += "<tr><td>Boleta:</td><td>" + ganador["bolCodigo"].ToString() + "</td></tr>";
        //            msgEmail += "<tr><td>Cliente:</td><td>" + ganador["conNom"].ToString().ToUpper() + " " + ganador["conApe"].ToString().ToUpper() + "</td></tr>";
        //            msgEmail += "<tr><td>Documento:</td><td>" + ganador["conNdoc"].ToString() + "</td></tr>";
        //            msgEmail += "<tr><td>Celular:</td><td>" + ganador["conCel"].ToString() + "</td></tr>";
        //            msgEmail += "<tr><td>Email:</td><td>" + ganador["conEmail"].ToString() + "</td></tr>";
        //            msgEmail += "</table>";
                                                                               

        //            _email.mensajeGanadorBono(ganador["conEmail"].ToString(), "", nombreCampania + " - " + ganador["conNdoc"].ToString(), _hora.Hour.ToString().PadLeft(2, '0') + ":" + _hora.Minute.ToString().PadLeft(2, '0'), msgEmail, "");
        //            //_email.mensajeGanadorBono("centrocomercialtintalplaza@gmail.com", "", nombreCampania + " - " + ganador["conNdoc"].ToString(), _hora.Hour.ToString().PadLeft(2, '0') + ":" + _hora.Minute.ToString().PadLeft(2, '0'), msgEmail, "");

        //        }
        //    }
        //}
    }
}