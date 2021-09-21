using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concesionario.GUI.Models.Parametros
{
    public class ModeloCategoriaGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        [Required]
        [MinLength(2)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}