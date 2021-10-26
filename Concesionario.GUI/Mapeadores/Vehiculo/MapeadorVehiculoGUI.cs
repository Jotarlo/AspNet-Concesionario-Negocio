using Concesionario.GUI.Models.Parametros;
using Concesionario.GUI.Models.Vehiculo;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.DTO.Vehiculo;
using System.Collections.Generic;

namespace Concesionario.GUI.Mapeadores.Vehiculo
{
    public class MapeadorVehiculoGUI : MapeadorBaseGUI<VehiculoDTO, ModeloVehiculoGUI>
    {
        public override ModeloVehiculoGUI MapearTipo1Tipo2(VehiculoDTO entrada)
        {
            return new ModeloVehiculoGUI()
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

        public override IEnumerable<ModeloVehiculoGUI> MapearTipo1Tipo2(IEnumerable<VehiculoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override VehiculoDTO MapearTipo2Tipo1(ModeloVehiculoGUI entrada)
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
                SerieMotor = entrada.SerieMotor
            };
        }

        public override IEnumerable<VehiculoDTO> MapearTipo2Tipo1(IEnumerable<ModeloVehiculoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}