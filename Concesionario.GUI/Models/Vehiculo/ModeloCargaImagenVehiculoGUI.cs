using Concesionario.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concesionario.GUI.Models.Vehiculo
{
    public class ModeloCargaImagenVehiculoGUI
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private HttpPostedFileBase archivo;

        [Required]
        public HttpPostedFileBase Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        private IEnumerable<ModeloFotoVehiculoGUI> listadoImagenesVehiculo;

        public IEnumerable<ModeloFotoVehiculoGUI> ListadoImagenesVehiculo
        {
            get { return listadoImagenesVehiculo; }
            set { listadoImagenesVehiculo = value; }
        }

        private String rutaImagenVehiculo = DatosGenerales.RutaMostrarArchivosVehiculo;

        public String RutaImagenVehiculo
        {
            get { return rutaImagenVehiculo; }
        }


    }
}