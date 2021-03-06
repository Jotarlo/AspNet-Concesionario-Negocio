using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concesionario.GUI.Models.Vehiculo
{
    public class ModeloVehiculoGUI
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string color;

        [Required]
        [DisplayName("Color")]
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        private int modelo;

        [Required]
        public int Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private string serie_chasis;

        [Required]
        [DisplayName("Serie del Chasis")]
        public string SerieChasis
        {
            get { return serie_chasis; }
            set { serie_chasis = value; }
        }

        private string serie_motor;

        [Required]
        [DisplayName("Serie del Motor")]
        public string SerieMotor
        {
            get { return serie_motor; }
            set { serie_motor = value; }
        }

        private int idMarca;

        [Required]
        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        private int idCategoria;

        [Required]
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        private int precio;

        [Required]
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int descuento;

        [Required]
        public int Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        private bool estado;

        [Required]
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int idProveedor;

        [Required]
        [DisplayName("Proveedor")]
        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        private string razonSocialProveedor;

        [DisplayName("Proveedor")]
        public string RazonSocialProveedor
        {
            get { return razonSocialProveedor; }
            set { razonSocialProveedor = value; }
        }

        private string nombreMarca;

        [DisplayName("Marca")]
        public string NombreMarca
        {
            get { return nombreMarca; }
            set { nombreMarca = value; }
        }

        private string nombreCategoria;

        [DisplayName("Categoría")]
        public string NombreCategoria
        {
            get { return nombreCategoria; }
            set { nombreCategoria = value; }
        }


    }
}