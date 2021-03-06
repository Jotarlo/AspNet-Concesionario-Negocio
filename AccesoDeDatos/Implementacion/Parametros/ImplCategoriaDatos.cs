using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplCategoriaDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<CategoriaDbModel> ListarRegistros(String filtro)
        {
            var lista = new List<tb_categoria>();
            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                // lista = bd.tb_categoria.Where(x => x.nombre.ToUpper().Contains(filtro.ToUpper())).ToList();
                lista = (
                    from c in bd.tb_categoria
                    where c.nombre.Contains(filtro)
                    select c
                    ).ToList();
            }
            return new MapeadorCategoriaDatos().MapearTipo1Tipo2(lista);
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(CategoriaDbModel registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_categoria.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    var reg = new MapeadorCategoriaDatos().MapearTipo2Tipo1(registro);
                    bd.tb_categoria.Add(reg);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método de búsqueda de un registro
        /// </summary>
        /// <param name="id">id del registro a buscar</param>
        /// <returns>el objeto con el id buscado o null cuando no exista</returns>
        public CategoriaDbModel BuscarRegistro(int id)
        {
            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                tb_categoria registro = bd.tb_categoria.Find(id);
                return new MapeadorCategoriaDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(CategoriaDbModel registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_categoria.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    tb_categoria reg = new MapeadorCategoriaDatos().MapearTipo2Tipo1(registro);
                    bd.Entry(reg).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método de eliminar un registro por el id
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns>true cuando se elimina, false cuando no existe el registro o una excepción</returns>
        public bool EliminarRegistro(int id)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    tb_categoria registro = bd.tb_categoria.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_categoria.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
