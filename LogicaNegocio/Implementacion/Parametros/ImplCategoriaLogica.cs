using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplCategoriaLogica
    {
        private ImplCategoriaDatos accesoDatos;
        public ImplCategoriaLogica()
        {
            this.accesoDatos = new ImplCategoriaDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<CategoriaDTO> ListarRegistros(String filtro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro);
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoriaDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean EditarRegistro(CategoriaDTO registro)
        {
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            CategoriaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(CategoriaDTO registro)
        {
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            CategoriaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
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
