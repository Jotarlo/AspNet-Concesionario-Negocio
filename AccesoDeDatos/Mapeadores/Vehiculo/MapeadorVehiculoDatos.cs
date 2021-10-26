using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Vehiculo
{
    public class MapeadorVehiculoDatos : MapeadorBaseDatos<tb_vehiculo, VehiculoDbModel>
    {
        public override VehiculoDbModel MapearTipo1Tipo2(tb_vehiculo entrada)
        {
            return new VehiculoDbModel()
            {
                Id = entrada.id,
                Color = entrada.color,
                Descuento = entrada.descuento,
                Estado = entrada.estado,
                IdCategoria = entrada.id_categoria,
                IdMarca = entrada.id_marca,
                IdProveedor = entrada.id_proveedor,
                Modelo = entrada.modelo,
                Precio = entrada.precio,
                SerieChasis = entrada.serie_chasis,
                SerieMotor = entrada.serie_motor,
                NombreCategoria = entrada.tb_categoria.nombre,
                NombreMarca = entrada.tb_marca.nombre,
                RazonSocialProveedor = entrada.tb_proveedor.razon_social
            };
        }

        public override IEnumerable<VehiculoDbModel> MapearTipo1Tipo2(IEnumerable<tb_vehiculo> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_vehiculo MapearTipo2Tipo1(VehiculoDbModel entrada)
        {
            return new tb_vehiculo()
            {
                id = entrada.Id,
                color = entrada.Color,
                descuento = entrada.Descuento,
                estado = entrada.Estado,
                id_categoria = entrada.IdCategoria,
                id_marca = entrada.IdMarca,
                id_proveedor = entrada.IdProveedor,
                modelo = entrada.Modelo,
                precio = entrada.Precio,
                serie_chasis = entrada.SerieChasis,
                serie_motor = entrada.SerieMotor
            };
        }

        public override IEnumerable<tb_vehiculo> MapearTipo2Tipo1(IEnumerable<VehiculoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}