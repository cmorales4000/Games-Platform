<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_BeginRequest(object sender, EventArgs e)
    {
        //if (!Request.Url.Host.StartsWith("www") && !Request.Url.IsLoopback)
        //{
        //    UriBuilder builder = new UriBuilder(Request.Url);
        //    builder.Host = "www." + Request.Url.Host;
        //    Response.StatusCode = 301;
        //    Response.AddHeader("Location", builder.ToString());
        //    Response.End();
        //}
    }
    void Application_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse la aplicación
        RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión

    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.

    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        //Defecto
        routes.MapPageRoute("Default", "", "~/Default.aspx");
        //Pagina de validacion de asistencia
        routes.MapPageRoute("Check", "Check/{key}", "~/Check.aspx");
        routes.MapPageRoute("Check2", "Check/{key}/{key2}", "~/Check.aspx");
        routes.MapPageRoute("Check3", "Check/{key}/{key2}/{key3}", "~/Check.aspx");
        routes.MapPageRoute("Check4", "Check/{key}/{key2}/{key3}/{key4}", "~/Check.aspx");
        routes.MapPageRoute("Check5", "Check/{key}/{key2}/{key3}/{key4}/{key5}", "~/Check.aspx");
        //Quitamos las extensiones
        routes.MapPageRoute("SinExtension", "{*file}", "~/{file}.aspx");
        routes.MapPageRoute("SinExtensionAshx", "{*file}", "~/{file}.ashx");
    }

</script>
