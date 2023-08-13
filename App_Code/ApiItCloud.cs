using System;
using System.Collections.Generic;
using System.Data;

public class ApiItCloud
{
    private static string _endPoint = "https://contacto-masivo.com/sms/back_sms/public/api/";
    //private static string _endPointDV = "https://sistemasmasivos.com/itcloud/api/sendsms/";
    private static string _endPointDV = "https://contacto-masivo.com/sms/back_sms/public/api/";
    //SMS de un sentido
    private static string _userApi = "YourUserApiData";
    private static string _pwdApi = "YourUserApiData";
    private static string _token = "YourUserApiData";
    private static string _metodo_envio = "1via";//'1via' '2via' 'flash'
    //SMS de Doble VIA
    private static string _userApiDV = "YourUserApiData";
    private static string _pwdApiDV = "YourUserApiData";
    private static string _tokenApiDV = "YourUserApiData";
    private static string _metodo_envioDV = "2via";//'1via' '2via' 'flash'

    public static string endPoint
    {
        get { return _endPoint; }
    }
    public static string endPointDV
    {
        get { return _endPointDV; }
    }
    public static string userApi
    {
        get { return _userApi; }
    }
    public static string pwdApi
    {
        get { return _pwdApi; }
    }
    public static string token
    {
        get { return _token; }
    }
    public static string metodo_envio
    {
        get { return _metodo_envio; }
    }
    public static string userApiDV
    {
        get { return _userApiDV; }
    }
    public static string pwdApiDV
    {
        get { return _pwdApiDV; }
    }
    public static string tokenApiDV
    {
        get { return _tokenApiDV; }
    }
    public static string metodo_envioDV
    {
        get { return _metodo_envioDV; }
    }
}