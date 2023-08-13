using System.Configuration;


    /// <summary>
    /// Descripción breve de ConexionDB
    /// </summary>
    public class ConexionDB
    {
        public static string dbProduccion = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
    }