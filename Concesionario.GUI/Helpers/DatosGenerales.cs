using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Concesionario.GUI.Helpers
{
    public static class DatosGenerales
    {
        public static int RegistrosPorPagina = Int32.Parse(ConfigurationManager.AppSettings["registrosPorPagina"].ToString());
        public static String RutaArchivosVehiculo = ConfigurationManager.AppSettings["rutaArchivosVehiculo"].ToString();
        public static String CarpetaFotosVehiculoEliminadas = ConfigurationManager.AppSettings["carpetaFotosVehiculoEliminadas"].ToString();
        public static String RutaMostrarArchivosVehiculo = ConfigurationManager.AppSettings["rutaMostrarArchivosVehiculo"].ToString();
    }
}