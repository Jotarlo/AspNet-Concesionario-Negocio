using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.Implementacion.Vehiculo;
using LogicaNegocio.DTO.Vehiculo;
using LogicaNegocio.Mapeadores.Vehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Vehiculo
{
    public class ImplVehiculoLogica
    {
        private ImplVehiculoDatos accesoDatos;
        public ImplVehiculoLogica()
        {
            this.accesoDatos = new ImplVehiculoDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<VehiculoDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            //totalRegistros = totalRegistrosLogica;
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VehiculoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean EditarRegistro(VehiculoDTO registro)
        {
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            VehiculoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(VehiculoDTO registro)
        {
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            VehiculoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }
    }
}
