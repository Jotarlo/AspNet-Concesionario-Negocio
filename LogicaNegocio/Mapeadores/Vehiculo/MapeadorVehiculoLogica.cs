
using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.ModeloDeDatos;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.DTO.Vehiculo;
using LogicaNegocio.Mapeadores.Parametros;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Vehiculo
{
    public class MapeadorVehiculoLogica : MapeadorBaseLogica<VehiculoDbModel, VehiculoDTO>
    {
        public override VehiculoDTO MapearTipo1Tipo2(VehiculoDbModel entrada)
        {
            return new VehiculoDTO()
            {
                Id = entrada.Id,
                Color = entrada.Color,
                Descuento = entrada.Descuento,
                Estado = entrada.Estado,
                IdCategoria = entrada.IdCategoria,
                IdMarca = entrada.IdMarca,
                IdProveedor = entrada.IdProveedor,
                Modelo = entrada.Modelo,
                Precio = entrada.Precio,
                SerieChasis = entrada.SerieChasis,
                SerieMotor = entrada.SerieMotor,
                NombreCategoria = entrada.NombreCategoria,
                NombreMarca = entrada.NombreMarca,
                RazonSocialProveedor = entrada.RazonSocialProveedor
            };
        }

        public override IEnumerable<VehiculoDTO> MapearTipo1Tipo2(IEnumerable<VehiculoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override VehiculoDbModel MapearTipo2Tipo1(VehiculoDTO entrada)
        {
            return new VehiculoDbModel()
            {
                Id = entrada.Id,
                Color = entrada.Color,
                Descuento = entrada.Descuento,
                Estado = entrada.Estado,
                IdCategoria = entrada.IdCategoria,
                IdMarca = entrada.IdMarca,
                IdProveedor = entrada.IdProveedor,
                Modelo = entrada.Modelo,
                Precio = entrada.Precio,
                SerieChasis = entrada.SerieChasis,
                SerieMotor = entrada.SerieMotor
            };
        }

        public override IEnumerable<VehiculoDbModel> MapearTipo2Tipo1(IEnumerable<VehiculoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}