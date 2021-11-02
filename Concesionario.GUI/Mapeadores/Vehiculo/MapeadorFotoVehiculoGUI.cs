using Concesionario.GUI.Models.Parametros;
using Concesionario.GUI.Models.Vehiculo;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.DTO.Vehiculo;
using System.Collections.Generic;

namespace Concesionario.GUI.Mapeadores.Vehiculo
{
    public class MapeadorFotoVehiculoGUI : MapeadorBaseGUI<FotoVehiculoDTO, ModeloFotoVehiculoGUI>
    {
        public override ModeloFotoVehiculoGUI MapearTipo1Tipo2(FotoVehiculoDTO entrada)
        {
            return new ModeloFotoVehiculoGUI()
            {
                Id = entrada.Id,
                IdVehiculo = entrada.IdVehiculo,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<ModeloFotoVehiculoGUI> MapearTipo1Tipo2(IEnumerable<FotoVehiculoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override FotoVehiculoDTO MapearTipo2Tipo1(ModeloFotoVehiculoGUI entrada)
        {
            return new FotoVehiculoDTO()
            {
                Id = entrada.Id,
                IdVehiculo = entrada.IdVehiculo,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<FotoVehiculoDTO> MapearTipo2Tipo1(IEnumerable<ModeloFotoVehiculoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}