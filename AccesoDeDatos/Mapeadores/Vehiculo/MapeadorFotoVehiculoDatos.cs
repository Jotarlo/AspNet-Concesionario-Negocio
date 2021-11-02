using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Vehiculo
{
    public class MapeadorFotoVehiculoDatos : MapeadorBaseDatos<tb_fotos, FotoVehiculoDbModel>
    {
        public override FotoVehiculoDbModel MapearTipo1Tipo2(tb_fotos entrada)
        {
            return new FotoVehiculoDbModel()
            {
                Id = entrada.id,
                IdVehiculo = entrada.id_vehiculo,
                NombreFoto = entrada.ruta
            };
        }

        public override IEnumerable<FotoVehiculoDbModel> MapearTipo1Tipo2(IEnumerable<tb_fotos> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_fotos MapearTipo2Tipo1(FotoVehiculoDbModel entrada)
        {
            return new tb_fotos()
            {
                id = entrada.Id,
                id_vehiculo = entrada.IdVehiculo,
                ruta = entrada.NombreFoto
            };
        }

        public override IEnumerable<tb_fotos> MapearTipo2Tipo1(IEnumerable<FotoVehiculoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}