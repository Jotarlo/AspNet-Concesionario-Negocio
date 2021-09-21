using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Vehiculo
{
    public class ImplVehiculoDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<tb_vehiculo> ListarRegistros(String filtro)
        {
            var lista = new List<tb_vehiculo>();
            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                lista = bd.tb_vehiculo.Where(x => x.serie_chasis.ToUpper().Contains(filtro.ToUpper())).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(tb_vehiculo registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_vehiculo.Where(x => x.serie_chasis.ToLower().Equals(registro.serie_chasis.ToLower())).Count() > 0)
                    {
                        return false;
                    }

                    bd.tb_vehiculo.Add(registro);
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
        public tb_vehiculo BuscarRegistro(int id)
        {
            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                tb_vehiculo registro = bd.tb_vehiculo.Find(id);
                return registro;
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(tb_vehiculo registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_vehiculo.Where(x => x.id == registro.id).Count() == 0)
                    {
                        return false;
                    }

                    bd.Entry(registro).State = EntityState.Modified;
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
                    tb_vehiculo registro = bd.tb_vehiculo.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_vehiculo.Remove(registro);
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
