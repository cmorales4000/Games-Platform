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

public partial class _Check : PageSession
{
    private string key = "";
    private string parametros = "";
    private List<DataTable> _lstDt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string empId = "", camId = "", locId = "", msgRta = "", smsEnvio = "", delivery = "", sLogo = "", sNombre="", sBol="";
            if (Page.RouteData.Values["key"] != null)
            {
                key = Page.RouteData.Values["key"].ToString();

                if (Page.RouteData.Values["key2"] != null)
                {
                    key += "/" + Page.RouteData.Values["key2"].ToString();

                    if (Page.RouteData.Values["key3"] != null)
                    {
                        key += "/" + Page.RouteData.Values["key3"].ToString();

                        if (Page.RouteData.Values["key4"] != null)
                        {
                            key += "/" + Page.RouteData.Values["key4"].ToString();

                            if (Page.RouteData.Values["key5"] != null)
                            {
                                key += "/" + Page.RouteData.Values["key5"].ToString();
                            }
                        }
                    }
                }
            }
            if (key == "")
            {
                Response.Redirect("/ErrorPage");
            }
            //En este punto debo tener el numero de local y haber iniciado la sesion
            //Desencriptamos la llave
            try
            {
                Validacion _encript = new Validacion();
                parametros = _encript.DesencryptarText(key);
                empId = parametros.Split('|')[0].Split('=')[1];
                camId = parametros.Split('|')[1].Split('=')[1];
                locId = parametros.Split('|')[2].Split('=')[1];


                _lstDt = Juegos.checkJuegos("M2J2", Session["conId"].ToString(), locId, "1", "19", "", "", "", "", "", "", "", "", empId);


                foreach (DataRow dr in _lstDt[1].Rows)
                {
                    sNombre = dr["locNom"].ToString();
                    sLogo = "/assets/images/DERROTADO.png";
                    //sLogo = (dr["locLogo"].ToString() == "" ? "/assets/images/DERROTADO.png" : "/assets/images/logos/" + dr["locLogo"].ToString());
                    sBol = dr["bol"].ToString();
                }


                if (_lstDt != null)
                {
                    if (_lstDt.Count > 1)
                    {
                        msgRta = _lstDt[2].Rows[0]["@msgRta"].ToString();
                        //if (_lstDt[0].Rows.Count > 0)
                        //{
                        //    DataRow drInfoSMS = _lstDt[0].Rows[0];
                        //    //Enviamos el SMS
                        //    if (drInfoSMS["smsEnvio"].ToString() == "1")
                        //    {
                        //        var client = new RestClient();

                        //        var request = new RestRequest();
                        //        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        //        client.BaseUrl = new Uri(ApiItCloud.endPoint);
                        //        request.Method = Method.POST;
                        //        request.Resource = "send/sms/json";
                        //        //SMS de una via
                        //        request.AddParameter("email", ApiItCloud.userApi, ParameterType.QueryString);
                        //        request.AddParameter("token", ApiItCloud.token, ParameterType.QueryString);
                        //        //request.AddParameter("individualws", "1", ParameterType.QueryString);
                        //        request.AddParameter("type_send", ApiItCloud.metodo_envio, ParameterType.QueryString);
                        //        request.AddParameter("data", "[{\"cellphone\":\"" + drInfoSMS["smsCelular"].ToString() + "\",\"message\":\"" + drInfoSMS["smsMensaje"].ToString() + "\"}]", ParameterType.QueryString);

                        //        IRestResponse response = client.Execute(request);
                        //        if (response.Content.Length > 0)
                        //        {
                        //            try
                        //            {
                        //                ResponseItCLoud responseItCLoud = JsonConvert.DeserializeObject<ResponseItCLoud>(response.Content);
                        //                smsEnvio = (responseItCLoud.status == "OK" ? "1" : "0");
                        //                delivery = response.Content;
                        //            }
                        //            catch (Exception ex)
                        //            {
                        //                delivery = ex.Message.ToString();
                        //            }
                        //            //ConsultasBasicas.actualizarBasico2("17", conId, "46", smsEnvio, delivery, drInfoSMS["smsCelular"].ToString(), drInfoSMS["smsMensaje"].ToString(), "", "", "", "", "", "-1", "46");
                        //        }
                        //    }
                        //}
                        if (msgRta == "OK")
                        {
                            dvMsgRta.InnerHtml += "<h2>¡¡Pirata derrotado!!</h2>";
                            dvMsgRta.InnerHtml += "<img src=\"" + sLogo + "\" class=\"text-center\" style=\"height:400px;width:280px;border:1px solid #3b3b3b;padding:5px;border-radius: 8px 8px 8px 8px;-moz-border-radius: 8px 8px 8px 8px;-webkit-border-radius: 8px 8px 8px 8px;\" />";
                            //dvMsgRta.InnerHtml += "<h2>"+ sNombre +"</h2>";
                        }
                        else if (msgRta == "FULL")
                        {
                            dvMsgRta.InnerHtml += "<h2>LO SIENTO, YA HA COMPLETADO LA CANTIDAD DE PARTICIPANTES PERMITIDOS PARA ESTE JUEGO </h2>";
                            dvMsgRta.InnerHtml += "<img src=\"" + sLogo + "\" class=\"text-center\" style=\"height:400px;width:280px;border:1px solid #3b3b3b;padding:5px;border-radius: 8px 8px 8px 8px;-moz-border-radius: 8px 8px 8px 8px;-webkit-border-radius: 8px 8px 8px 8px;\" />";
                        }
                        else if (msgRta == "OK2")
                        {
                            //dvMsgRta.InnerHtml += "<h2>¡¡Pirata derrotado!!</h2>";
                            dvMsgRta.InnerHtml += "<h2>¡¡GANASTE!!</h2>";
                            dvMsgRta.InnerHtml += "<img src=\"/assets/images/FINAL.JPG\" class=\"text-center\" style=\"height:400px;width:280px;border:1px solid #3b3b3b;padding:5px;border-radius: 8px 8px 8px 8px;-moz-border-radius: 8px 8px 8px 8px;-webkit-border-radius: 8px 8px 8px 8px;\" />";
                            dvMsgRta.InnerHtml += "<h2>Tu código para el sorteo es: " + sBol + "</h2>";

                            _lstDt = Juegos.checkJuegos("M6", conId, "", "", "", "", "", "", "", "", "", "", "", "");
                            if (_lstDt != null)
                            {
                                if (_lstDt.Count > 0)
                                {
                                    if (_lstDt[0].Rows.Count > 0)
                                    {
                                        //DataRow ganador = _lstDt[0].Rows[0];
                                        ////DataRow compraGanadora = _lstDt[1].Rows[0];
                                        //DateTime _hora = DateTime.Now;

                                        //string msgEmail = "";
                                        //string nombreCampania = "EL TESORO DE LA PLAZA SHOPPING";
                                        //string nombreTitulo = "EL TESORO DE LA PLAZA SHOPPING";


                                        //EnviarEmail _email = new EnviarEmail();

                                        //msgEmail += "<table style=\"width:100%;\">";
                                        //msgEmail += "<tr><td colspan=\"2\"><h1 style=\"text-align: center; line-height: 130%; \">" + nombreTitulo + "</h1></td></tr>";
                                        //msgEmail += "<tr><td>Boleta:</td><td>" + sBol + "</td></tr>";
                                        //msgEmail += "<tr><td>Cliente:</td><td>" + ganador["conNom"].ToString().ToUpper() + " " + ganador["conApe"].ToString().ToUpper() + "</td></tr>";
                                        //msgEmail += "<tr><td>Documento:</td><td>" + ganador["conNdoc"].ToString() + "</td></tr>";
                                        //msgEmail += "<tr><td>Celular:</td><td>" + ganador["conCel"].ToString() + "</td></tr>";
                                        //msgEmail += "<tr><td>Email:</td><td>" + ganador["conEmail"].ToString() + "</td></tr>";
                                        //msgEmail += "</table>";


                                        //_email.mensajeGanadorBono(ganador["conEmail"].ToString(), "", nombreCampania + " - " + ganador["conNdoc"].ToString(), _hora.Hour.ToString().PadLeft(2, '0') + ":" + _hora.Minute.ToString().PadLeft(2, '0'), msgEmail, "");
                                        //_email.mensajeGanadorBono("centrocomercialtintalplaza@gmail.com", "", nombreCampania + " - " + ganador["conNdoc"].ToString(), _hora.Hour.ToString().PadLeft(2, '0') + ":" + _hora.Minute.ToString().PadLeft(2, '0'), msgEmail, "");

                                    }
                                }
                            }

                        }
                        else
                        {
                            dvMsgRta.InnerHtml += "<h2>" + msgRta + "</h2>";
                            dvMsgRta.InnerHtml += "<img src=\"" + sLogo + "\" class=\"text-center\" style=\"height:400px;width:280px;border:1px solid #3b3b3b;padding:5px;border-radius: 8px 8px 8px 8px;-moz-border-radius: 8px 8px 8px 8px;-webkit-border-radius: 8px 8px 8px 8px;\" />";
                            dvMsgRta.InnerHtml += "<h2>" + sNombre + "</h2>";
                        }
                    }
                    else
                    {
                        dvMsgRta.InnerHtml = "<h2>Se ha presentado una excepción</h2>";
                    }
                }
                else
                {
                    dvMsgRta.InnerHtml = "<h2>Se ha presentado una excepción</h2>";
                }

            }
            catch(Exception ex)
            {
                Response.Redirect("/ErrorPage");
                LogError.insertarLog("Check", "Page_Load", key, ex.StackTrace.ToString(), "", empId);
            }



        }
        catch (Exception ex)
        {
            Response.Redirect("/ErrorPage");
            LogError.insertarLog("Check", "Page_Load", key, ex.StackTrace.ToString(), "", "54");
        }
    }
}