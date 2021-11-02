using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.ModeloDeDatos;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.DTO.Vehiculo;
using LogicaNegocio.Mapeadores.Parametros;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Vehiculo
{
    public class MapeadorFotoVehiculoLogica : MapeadorBaseLogica<FotoVehiculoDbModel, FotoVehiculoDTO>
    {
        public override FotoVehiculoDTO MapearTipo1Tipo2(FotoVehiculoDbModel entrada)
        {
            return new FotoVehiculoDTO()
            {
                Id = entrada.Id,
                IdVehiculo = entrada.IdVehiculo,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<FotoVehiculoDTO> MapearTipo1Tipo2(IEnumerable<FotoVehiculoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override FotoVehiculoDbModel MapearTipo2Tipo1(FotoVehiculoDTO entrada)
        {
            return new FotoVehiculoDbModel()
            {
                Id = entrada.Id,
                IdVehiculo = entrada.IdVehiculo,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<FotoVehiculoDbModel> MapearTipo2Tipo1(IEnumerable<FotoVehiculoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}