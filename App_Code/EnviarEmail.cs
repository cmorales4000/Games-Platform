using System;
using System.Web;
using System.Net;
using System.Net.Mail;
using SendGrid;
using System.Configuration;

/// <summary>
/// Descripción breve de EnviarEmail
/// </summary>
public class EnviarEmail
{
    private string _serverSMTP = ConfigurationManager.AppSettings["serverSMTP"].ToString();
    private string _userSMTP = ConfigurationManager.AppSettings["userSMTP"].ToString();
    private string _pwdSMTP = ConfigurationManager.AppSettings["pwdSMTP"].ToString();
    private string _apiKey = ConfigurationManager.AppSettings["apiKey"].ToString();
    private string _emailSMTP = ConfigurationManager.AppSettings["emailSMTP"].ToString();
    private string _nombreEnvia = ConfigurationManager.AppSettings["nombreEnvia"].ToString();
    public EnviarEmail()
    {
    }

    private string plantillaEmail(string titulo)
    {
        string plantilla = "";
        plantilla += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
        plantilla += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
        plantilla += "<head>";
        plantilla += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />";
        plantilla += "<title>" + titulo + "</title>";
        plantilla += "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />";
        plantilla += "</head>";
        plantilla += "<body>";
        plantilla += "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600px\" style=\"border-collapse: collapse;\">";
        //plantilla += headerEmail();
        plantilla += "<tr>";
        plantilla += "<td bgcolor=\"#FFFFFF\">";
        plantilla += "<!--CONTENIDO-->";
        plantilla += "</td>";
        plantilla += "</tr>";
        plantilla += footerEmail();
        plantilla += "</table>";
        plantilla += "</body>";
        plantilla += "</html>";
        return plantilla;
    }


    private string footerEmail()
    {
        string footer = "";
        footer += "<tr>";
        footer += "<td style=\"padding: 30px 30px 30px 30px; color: #E37307;\">";

        footer += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
        footer += "<tr>";
        footer += "<td style=\"color:#404040; font-family: Arial, sans-serif; font-size: 12px;\">";
        footer += "</td>";
        footer += "</tr>";
        footer += "</table>";

        footer += "</td>";
        footer += "</tr>";
        return footer;
    }

    public bool mensajeGanadorBono(string email1, string email2, string asunto, string hora, string contenidoEmail, string ganador)
    {
        Validacion val = new Validacion();
        string str_URLBase = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + '/';
        string cuerpo = plantillaEmail("Mensaje Navidad");
        string contenido = "";
        bool bSend = true;
        contenido += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
        contenido += "<tr>";
        contenido += "<td style=\"font-family: Arial, sans-serif; font-size: 20px; line-height: 14px;\">";
        contenido += contenidoEmail;
        contenido += "</td>";
        contenido += "</tr>";
        contenido += "</table>";

        cuerpo = cuerpo.Replace("<!--CONTENIDO-->", contenido);

        try
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new SendGridClient(_apiKey);
            var msg = new SendGrid.Helpers.Mail.SendGridMessage()
            {
                From = new SendGrid.Helpers.Mail.EmailAddress(_emailSMTP, _nombreEnvia),
                Subject = asunto,
                //PlainTextContent = "and easy to do anywhere, even with C#",
                HtmlContent = cuerpo
            };
            msg.AddTo(email1);
            if (email2 != "")
            {
                msg.AddCc(email2);

            }
            var response = client.SendEmailAsync(msg).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            string error = "";
            if (ex.GetType() == typeof(Exceptions.InvalidApiRequestException))
            {
                HttpStatusCode code = ((Exceptions.InvalidApiRequestException)ex).ResponseStatusCode;
                string strCode = ((byte)code).ToString();
                error += "\nSTATUS CODE: " + strCode + " ";// +code.GetDescription();
                error += "\n\nERRORS: ";
                foreach (string err in ((Exceptions.InvalidApiRequestException)ex).Errors)
                {
                    error += "\n" + err;
                }
            }
            logError(ex, "mensajeGanadorBono", error);
            bSend = false;
        }
        return bSend;
    }
    public void logError(Exception ex, String funcion, String parametros)
    {
        LogError.insertarLog(HttpContext.Current.Request.Url.AbsolutePath, funcion, parametros, ex.Message.ToString() + ";" + ex.StackTrace.ToString(), "-1", "-1");
    }
}