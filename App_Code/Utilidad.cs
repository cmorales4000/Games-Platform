using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;


public class Utilidad
{
    private static Dictionary<string, string> _meses = new Dictionary<string, string>() 
    { 
        {"01","Enero"},
        {"02","Febrero"},
        {"03","Marzo"},
        {"04","Abril"},
        {"05","Mayo"},
        {"06","Junio"},
        {"07","Julio"},
        {"08","Agosto"},
        {"09","Septiembre"},
        {"10","Octubre"},
        {"11","Noviembre"},
        {"12","Diciembre"}
    };

    //public Utilidad() { }

    /// <summary>
    /// Get current user ip address.
    /// </summary>
    /// <returns>The IP Address</returns>
    public static string GetUserIPAddress()
    {
        var context = System.Web.HttpContext.Current;
        string ip = String.Empty;

        if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
            ip = context.Request.UserHostAddress;

        if (ip == "::1")
            ip = "127.0.0.1";

        return ip;  

    }

    public static string meses(string key)
    {
        string value = "";
        if (_meses.ContainsKey(key))
        {
            value = _meses[key].ToString();
        }
        return value;
    }


    public static DataTable dtAnnio()
    {
        DataTable dtTmp = new DataTable("dtAnnio");
        DataRow drTmp;
        dtTmp.Columns.Add("key", Type.GetType("System.String"));
        dtTmp.Columns.Add("value", Type.GetType("System.String"));

        for (int i = 2012; i <= Convert.ToInt32(DateTime.Now.Year.ToString()); i++)
        {
            drTmp = dtTmp.NewRow();
            drTmp["key"] = i.ToString();
            drTmp["value"] = i.ToString();
            dtTmp.Rows.Add(drTmp);
        }

        return dtTmp;
    }

    public static DataTable dtAnnio(int AnnioInicio, int AnnioFinal, int orden)
    {
        DataTable dtTmp = new DataTable("dtAnnio");
        DataRow drTmp;
        dtTmp.Columns.Add("key", Type.GetType("System.String"));
        dtTmp.Columns.Add("value", Type.GetType("System.String"));

        if(orden == 1)
        {
            for (int i = AnnioInicio; i <= AnnioFinal; i++)
            {
                drTmp = dtTmp.NewRow();
                drTmp["key"] = i.ToString();
                drTmp["value"] = i.ToString();
                dtTmp.Rows.Add(drTmp);
            }
        }
        else if (orden == 0)
        {
            for (int i = AnnioInicio; i >= AnnioFinal; i--)
            {
                drTmp = dtTmp.NewRow();
                drTmp["key"] = i.ToString();
                drTmp["value"] = i.ToString();
                dtTmp.Rows.Add(drTmp);
            }
        }

        return dtTmp;
    }

    public static DataTable dtMes()
    {
        DataTable dtTmp = new DataTable("dtMeses");
        DataRow drTmp;
        dtTmp.Columns.Add("key", Type.GetType("System.String"));
        dtTmp.Columns.Add("value", Type.GetType("System.String"));
        //Enero
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "01";
        drTmp["value"] = "Enero";
        dtTmp.Rows.Add(drTmp);
        //Febrero
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "02";
        drTmp["value"] = "Febrero";
        dtTmp.Rows.Add(drTmp);
        //Marzo
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "03";
        drTmp["value"] = "Marzo";
        dtTmp.Rows.Add(drTmp);
        //Abril
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "04";
        drTmp["value"] = "Abril";
        dtTmp.Rows.Add(drTmp);
        //Mayo
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "05";
        drTmp["value"] = "Mayo";
        dtTmp.Rows.Add(drTmp);
        //Junio
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "06";
        drTmp["value"] = "Junio";
        dtTmp.Rows.Add(drTmp);
        //Julio
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "07";
        drTmp["value"] = "Julio";
        dtTmp.Rows.Add(drTmp);
        //Agosto
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "08";
        drTmp["value"] = "Agosto";
        dtTmp.Rows.Add(drTmp);
        //Septiembre
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "09";
        drTmp["value"] = "Septiembre";
        dtTmp.Rows.Add(drTmp);
        //Octubre
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "10";
        drTmp["value"] = "Octubre";
        dtTmp.Rows.Add(drTmp);
        //Noviembre
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "11";
        drTmp["value"] = "Noviembre";
        dtTmp.Rows.Add(drTmp);
        //Diciembre
        drTmp = dtTmp.NewRow();
        drTmp["key"] = "12";
        drTmp["value"] = "Diciembre";
        dtTmp.Rows.Add(drTmp);

        return dtTmp;
    }
    
    public static string GenerateSlug(string phrase)
    {
        string str = RemoveAccent(phrase).ToUpper();
        // invalid chars           
        str = Regex.Replace(str, @"[^A-Z0-9_\s-]", "");
        // convert multiple spaces into one space   
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim 
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        str = Regex.Replace(str, @"\s", "-"); // hyphens   
        return str;
    }
    public static string GenerateSlugMin(string phrase)
    {
        string str = RemoveAccent(phrase).ToUpper();
        // invalid chars           
        str = Regex.Replace(str, @"[^A-Z0-9_\s-]", "");
        // convert multiple spaces into one space   
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim 
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        str = Regex.Replace(str, @"\s", ""); // hyphens   
        return str.ToLower();
    }
    public static string RemoveAccent(string txt)
    {
        byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
        return System.Text.Encoding.ASCII.GetString(bytes);
    }

    public static DataTable dtCreatePromedio()
    {
        DataTable dtPro = new DataTable();
        dtPro.Columns.Add("per_id", typeof(int));
        dtPro.Columns.Add("obj_id", typeof(int));
        dtPro.Columns.Add("ind_id", typeof(int));
        dtPro.Columns.Add("ind_fecha", typeof(DateTime));
        dtPro.Columns.Add("ind_promedio", typeof(decimal));

        return dtPro;
    }

    public static string sIcon(string file)
    {
        string icon = "fa fa-file";
        string extension = file.Substring(file.LastIndexOf('.') + 1).ToLower();
        switch (extension)
        {
            case "xls":
            case "xlsx":
                icon = "fa fa-file-excel-o";
                break;
            case "doc":
            case "docx":
                icon = "fa fa-file-word-o";
                break;
            case "pdf":
                icon = "fa fa-file-pdf-o";
                break;
            case "zip":
            case "rar":
                icon = "fa fa-file-zip-o";
                break;
            case "png":
            case "jpg":
            case "gif":
                icon = "fa fa-file-image-o";
                break;
        }

        return icon;
    }

    private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
    public static string RandomString(int size)
    {
        StringBuilder builder = new StringBuilder();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }

        return builder.ToString().ToLower();
    }

    public static string paginate(string url, string parametros, string capa, string callback, int pagina, int tamanio, int total)
    {
        string salidaHtml = "";
        try
        {
            String enlace = "";
            int contador = 1;
            salidaHtml = "<div class=\"text-center\" style=\"font-family: 'Merriweather Sans', sans-serif;font-size: 13px;font-weight: 400;\">";
            salidaHtml += "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\">";
            salidaHtml += "<tr><td style=\"text-align:left;\">Total&nbsp;Registros:&nbsp;" + total + "</td>";
            //Agregamos el boton de la primera pagina
            enlace = pagina != 1 ? enlace = " onclick='javascript:ejecutarAjax(\"" + url + "\",\"" + parametros + "&pageActual=1&tamanioPage=" + tamanio + "\",\"" + capa + "\",\"" + callback + "\");'" : " onclick='javascript:;'";
            salidaHtml += "<td><ul class=\"pagination pagination-centered\"><li><a href=\"javascript:;\" " + enlace + ">&lt;&lt;&nbsp;Primero</a></li>";
            while (total > 0)
            {
                total = total - tamanio;
                contador++;
            }
            contador--;
            //Agregamos el boton anterior
            enlace = (((pagina - 1) >= 1) && ((pagina - 1) < contador)) ? enlace = " onclick='javascript:ejecutarAjax(\"" + url + "\",\"" + parametros + "&pageActual=" + (pagina - 1) + "&tamanioPage=" + tamanio + "\",\"" + capa + "\",\"" + callback + "\");'" : " onclick='javascript:;'";
            salidaHtml += "<li><a href=\"javascript:;\" " + enlace + ">&lt;&nbsp;Anterior</a></li>";
            //Agregamos el boton siguiente
            enlace = ((pagina + 1) <= contador) ? enlace = " onclick='javascript:ejecutarAjax(\"" + url + "\",\"" + parametros + "&pageActual=" + (pagina + 1) + "&tamanioPage=" + tamanio + "\",\"" + capa + "\",\"" + callback + "\");'" : " onclick='javascript:;'";
            salidaHtml += "<li><a href=\"javascript:;\" " + enlace + " >Siguiente&nbsp;&gt;</a></li>";
            //Agregamos el boton de la ultima pagina
            enlace = pagina != contador ? enlace = " onclick='javascript:ejecutarAjax(\"" + url + "\",\"" + parametros + "&pageActual=" + contador + "&tamanioPage=" + tamanio + "\",\"" + capa + "\",\"" + callback + "\");'" : " onclick='javascript:;'";
            salidaHtml += "<li><a href=\"javascript:;\" " + enlace + ">Último&nbsp;&gt;&gt;</a></li></ul></td>";
            //Agregamos mensaje de la pagina
            salidaHtml += "<td style=\"text-align:right;\">P&aacute;gina:&nbsp;" + pagina + "/" + contador + "</td>";
            salidaHtml += "</tr>";
            salidaHtml += "</table></div>";
        }
        catch (Exception ex)
        {
            salidaHtml = "";
            LogError.insertarLog("Utilidad.cs", "paginate", "", ex.Message.ToString(), "", "");
        }
        return salidaHtml;
    }

    public static void llenarCombo(DataTable dt, DropDownList ddl, String key, String value)
    {
        try
        {
            ddl.DataSource = dt;
            ddl.DataTextField = value;
            ddl.DataValueField = key;
            ddl.DataBind();
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Utilidad.cs", "llenarCombo", "", ex.Message.ToString(), "", "");
        }
    }

    public static void llenarCombo(DataTable dt, DropDownList ddl, String key, String value, String selecionar)
    {
        try
        {
            ddl.DataSource = dt;
            ddl.DataTextField = value;
            ddl.DataValueField = key;
            ddl.DataBind();
            if (selecionar != "")
            {
                ddl.Items.Insert(0, new ListItem(selecionar, "-"));
            }
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Utilidad.cs", "llenarCombo", "SobreCarga", ex.Message.ToString(), "", "");
        }
    }

    public static void llenarListBox(DataTable dt, ListBox ddl, String key, String value)
    {
        try
        {
            ddl.DataSource = dt;
            ddl.DataTextField = value;
            ddl.DataValueField = key;
            ddl.DataBind();
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Utilidad.cs", "llenarCombo", "", ex.Message.ToString(), "", "");
        }
    }

    public static void llenarListBox(DataTable dt, ListBox ddl, String key, String value, String selecionar)
    {
        try
        {
            ddl.DataSource = dt;
            ddl.DataTextField = value;
            ddl.DataValueField = key;
            ddl.DataBind();
            if (selecionar != "")
            {
                ddl.Items.Insert(0, new ListItem(selecionar, "-"));
            }
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Utilidad.cs", "llenarCombo", "SobreCarga", ex.Message.ToString(), "", "");
        }
    }

    public static string containsKey(Dictionary<string, string> listKeys, string key)
    {
        if (listKeys.ContainsKey(key))
        {
            return listKeys[key].ToString();
        }
        else
        {
            return "";
        }
    }

    public static string containsKey(Dictionary<string, decimal> listKeys, string key)
    {
        if (listKeys.ContainsKey(key))
        {
            return listKeys[key].ToString();
        }
        else
        {
            return "";
        }
    }

    public static string IDropDownList(DataTable dt, Dictionary<string, string> property, string key, string value, string seleccione)
    {
        string control = "";
        control += "<select id=\"" + Utilidad.containsKey(property, "id") + "\" name=\"" + Utilidad.containsKey(property, "id") + "\"";
        control += Utilidad.containsKey(property, "onchange") != "" ? " onchange=\"" + Utilidad.containsKey(property, "onchange") + "\"" : "";
        control += Utilidad.containsKey(property, "onclick") != "" ? " onclick=\"" + Utilidad.containsKey(property, "onclick") + "\"" : "";
        control += Utilidad.containsKey(property, "style") != "" ? " style=\"" + Utilidad.containsKey(property, "style") + "\"" : "";
        control += Utilidad.containsKey(property, "class") != "" ? " class=\"" + Utilidad.containsKey(property, "class") + "\"" : "";
        control += ">";
        control += seleccione != "" ? "<option value=\"-\">" + seleccione + "</option>" : "";
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string escogida = ((Utilidad.containsKey(property, "selectValue") == dr[key].ToString()) ? "selected=\"true\"" : "");
                    control += "<option value=\"" + dr[key] + "\" " + escogida + ">" + dr[value] + "</option>";
                }
            }
        }
        control += "</select>";
        return control;
    }

    public static String serializeDt(DataTable dt)
    {
        String serialize = "[";
        try
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    serialize += "{";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        serialize += "'" + dc.ColumnName + "':'" + dr[dc.ColumnName] + "',";
                    }
                    serialize = serialize.Substring(0, serialize.Length - 1);
                    serialize += "},";
                }
                serialize = serialize.Substring(0, serialize.Length - 1);
            }
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Utilidad.cs", "serializeDt", "", ex.Message.ToString(), "", "");
        }
        serialize += "]";
        return serialize;
    }

    public static string Serialize<T>(T dataToSerialize)
    {
        try
        {
            var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stringwriter, dataToSerialize, emptyNs);
            return stringwriter.ToString();
        }
        catch
        {
            throw;
        }
    }

    public static T Deserialize<T>(string xmlText)
    {
        try
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
        catch
        {
            throw;
        }
    }

    public static string convertHM(string horaC)
    {
        string retorno = "";
        string hora = horaC.Substring(0, 2);
        string minuto = horaC.Substring(3, 2);
        if (Convert.ToInt32(hora) > 12)
        {
            retorno = Convert.ToString(Convert.ToInt32(hora) - 12) + ":" + minuto + " PM";
        }
        else if (hora == "00")
        {
            retorno = "12:" + minuto + " AM";
        }
        else
        {
            retorno = Convert.ToString(Convert.ToInt32(hora)) + ":" + minuto + " AM";
        }

        return retorno;
    }

    public static string convertHMCalendar(string horaC)
    {
        string retorno = "";
        string hora = horaC.Substring(0, 2);
        string minuto = horaC.Substring(3, 2);
        if (Convert.ToInt32(hora) > 12)
        {
            retorno = Convert.ToString(Convert.ToInt32(hora) - 12) + ":" + minuto + " p.m.";
        }
        else if (hora == "00")
        {
            retorno = "12:" + minuto + " a.m.";
        }
        else
        {
            retorno = Convert.ToString(Convert.ToInt32(hora)) + ":" + minuto + " a.m.";
        }

        return retorno;
    }

    public static string convertFL(string fecha)
    {
        string dia = fecha.Substring(3, 2);
        string mes = fecha.Substring(0, 2);
        string annio = fecha.Substring(6, 4);

        return dia + "&nbsp;" + Utilidad.containsKey(_meses, mes) + "&nbsp;" + annio;
    }

    public static string convertFLCo(string fecha)
    {
        string dia = fecha.Substring(0, 2);
        string mes = fecha.Substring(3, 2);
        string annio = fecha.Substring(6, 4);

        return dia +  " " + Utilidad.containsKey(_meses, mes) + " " + annio;
    }

    //Render Campos de Personalizacion
    public static string camelCase(string valor)
    {
        valor = valor.ToLower();
        if (valor.Length > 1)
        {
            valor = valor.Substring(0, 1).ToUpper() + valor.Substring(1);
        }
        return valor;
    }

    public static void ToCSV(DataTable dtDataTable, string strFilePath)
    {
        StreamWriter sw = new StreamWriter(strFilePath, false);
        //headers    
        for (int i = 0; i < dtDataTable.Columns.Count; i++)
        {
            sw.Write(dtDataTable.Columns[i]);
            if (i < dtDataTable.Columns.Count - 1)
            {
                sw.Write(";");
            }
        }
        sw.Write(sw.NewLine);
        foreach (DataRow dr in dtDataTable.Rows)
        {
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    string value = dr[i].ToString();
                    if (value.Contains(";"))
                    {
                        value = String.Format("\"{0}\"", value);
                        sw.Write(value);
                    }
                    else
                    {
                        sw.Write(dr[i].ToString());
                    }
                }
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
    }    

    #region validacion
    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsValidPassword(string password)
    {
        //Entre 7 y 20 Caracteres, por lo menos un digito y un alfanumérico, y no puede contener caracteres espaciales
        return Regex.IsMatch(password, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{7,20})$");
    }
    public static bool IsValidDate(string date)
    {
        //Entre 7 y 20 Caracteres, por lo menos un digito y un alfanumérico, y no puede contener caracteres espaciales
        return Regex.IsMatch(date, @"^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$");
    }
    public static string validaCampo(object objcad, string modo)
    {
        string cad = (objcad == null ? "" : objcad.ToString());
        string rta = "";
        int temp;
        decimal tempDec;

        if (modo == "int")
        {
            rta = (cad != "" && cad != null && (int.TryParse(cad, out temp)) ? cad : "0");
        }
        else if (modo == "dec")
        {
            rta = (cad != "" && cad != null && (decimal.TryParse(cad, out tempDec)) ? cad : "0");
        }
        else // modo == "str"
        {
            rta = (cad != "" && cad != null ? cad : "");
        }

        return rta;
    }
    #endregion
}
public static class SUtilidad
{
    public static string ConvertToBase64(this Stream stream)
    {
        var bytes = new Byte[(int)stream.Length];

        stream.Seek(0, SeekOrigin.Begin);
        stream.Read(bytes, 0, (int)stream.Length);

        return Convert.ToBase64String(bytes);
    }
}