﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concesionario.GUI.Models.Vehiculo
{
    public class ModeloFotoVehiculoGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private int idVehiculo;

        public int IdVehiculo
        {
            get { return idVehiculo; }
            set { idVehiculo = value; }
        }

        private String nombreFoto;

        public String NombreFoto
        {
            get { return nombreFoto; }
            set { nombreFoto = value; }
        }

    }
}