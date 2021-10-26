using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Vehiculo
{
    public class VehiculoDTO
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        private int modelo;

        public int Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private string serie_chasis;

        public string SerieChasis
        {
            get { return serie_chasis; }
            set { serie_chasis = value; }
        }

        private string serie_motor;

        public string SerieMotor
        {
            get { return serie_motor; }
            set { serie_motor = value; }
        }

        private int idMarca;

        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        private int idCategoria;

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int descuento;

        public int Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        private bool estado;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int idProveedor;

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        private string razonSocialProveedor;

        public string RazonSocialProveedor
        {
            get { return razonSocialProveedor; }
            set { razonSocialProveedor = value; }
        }

        private string nombreMarca;

        public string NombreMarca
        {
            get { return nombreMarca; }
            set { nombreMarca = value; }
        }

        private string nombreCategoria;

        public string NombreCategoria
        {
            get { return nombreCategoria; }
            set { nombreCategoria = value; }
        }
    }
}
