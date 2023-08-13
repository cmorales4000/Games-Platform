using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;

public class Seguridad
{
    public static List<DataTable> iniciarSession(string usuEmail, string usuPass, string usuPassPin, string usuario, string ip, string ciudad, string empId)
    {
        List<DataTable> functionReturnValue = null;
        List<DataTable> lstDt = new List<DataTable>();
        try
        {
            List<Parametros> lstParams = new List<Parametros>();
            lstParams.Add(new Parametros("@usuEmail", SqlDbType.VarChar, usuEmail, ParameterDirection.Input, 100));
            lstParams.Add(new Parametros("@usuPass", SqlDbType.VarChar, usuPass, ParameterDirection.Input, 50));
            lstParams.Add(new Parametros("@usuPassPin", SqlDbType.VarChar, usuPassPin, ParameterDirection.Input, 50));
            lstParams.Add(new Parametros("@ip", SqlDbType.VarChar, ip, ParameterDirection.Input, 50));
            lstParams.Add(new Parametros("@ciudad", SqlDbType.VarChar, ciudad, ParameterDirection.Input, 50));
            lstParams.Add(new Parametros("@msgRta", SqlDbType.VarChar, DBNull.Value, ParameterDirection.Output, 1000));

            lstDt = ConsultaDatos.executeStoreProcedure("PA_SITE_LOGIN", lstParams, ConexionDB.dbProduccion);
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Seguridad.cs", "iniciarSession", "", ex.Message.ToString(), usuario, "");
        }
        finally
        {
            functionReturnValue = lstDt;
        }
        return functionReturnValue;
    }



    public static List<DataTable> iniciarSessionCont(string usuNdoc, string usuPass, string usuario, string empId)
    {
        List<DataTable> functionReturnValue = null;
        List<DataTable> lstDt = new List<DataTable>();
        try
        {
            List<Parametros> lstParams = new List<Parametros>();
            lstParams.Add(new Parametros("@conNdoc", SqlDbType.VarChar, usuNdoc, ParameterDirection.Input, 100));
            lstParams.Add(new Parametros("@conPass", SqlDbType.VarChar, usuPass, ParameterDirection.Input, 50));
            // lstParams.Add(new Parametros("@empUrl", SqlDbType.VarChar, empUrl, ParameterDirection.Input, 100));
            lstParams.Add(new Parametros("@msgRta", SqlDbType.VarChar, DBNull.Value, ParameterDirection.Output, 1000));

            lstDt = ConsultaDatos.executeStoreProcedure("PA_SITE_LOGIN_CONTACTO", lstParams, ConexionDB.dbProduccion);
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Seguridad.cs", "iniciarSessionCont", "", ex.Message.ToString(), usuario, empId);
        }
        finally
        {
            functionReturnValue = lstDt;
        }
        return functionReturnValue;
    }

    public static List<DataTable> iniciarSessionPin(string usuNdoc, string usuPass, string usuario, string empId)
    {
        List<DataTable> functionReturnValue = null;
        List<DataTable> lstDt = new List<DataTable>();
        try
        {
            List<Parametros> lstParams = new List<Parametros>();
            lstParams.Add(new Parametros("@conNdoc", SqlDbType.VarChar, usuNdoc, ParameterDirection.Input, 100));
            lstParams.Add(new Parametros("@conPass", SqlDbType.VarChar, usuPass, ParameterDirection.Input, 50));
            lstParams.Add(new Parametros("@empId", SqlDbType.VarChar, empId, ParameterDirection.Input, 100));
            lstParams.Add(new Parametros("@msgRta", SqlDbType.VarChar, DBNull.Value, ParameterDirection.Output, 1000));

            lstDt = ConsultaDatos.executeStoreProcedure("PA_SITE_LOGIN_PIN", lstParams, ConexionDB.dbProduccion);
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Seguridad.cs", "iniciarSessionPin", "", ex.Message.ToString(), usuario, empId);
        }
        finally
        {
            functionReturnValue = lstDt;
        }
        return functionReturnValue;
    }

    public static List<DataTable> validarEmail(string usuEmail, string usuario, string idEmpresa)
    {
        List<DataTable> functionReturnValue = null;
        List<DataTable> lstDt = new List<DataTable>();
        try
        {
            List<Parametros> lstParams = new List<Parametros>();
            lstParams.Add(new Parametros("@usuEmail", SqlDbType.VarChar, usuEmail, ParameterDirection.Input, 100));
            lstParams.Add(new Parametros("@msgRta", SqlDbType.VarChar, DBNull.Value, ParameterDirection.Output, 1000));

            lstDt = ConsultaDatos.executeStoreProcedure("PA_TARC_VALIDAR_EMAIL", lstParams, ConexionDB.dbProduccion);
        }
        catch (Exception ex)
        {
            LogError.insertarLog("Seguridad.cs", "validarEmail", "", ex.Message.ToString(), usuario, idEmpresa);
        }
        finally
        {
            functionReturnValue = lstDt;
        }
        return functionReturnValue;
    }

}