using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.Mapeadores.Vehiculo;
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
        public IEnumerable<VehiculoDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<VehiculoDbModel>();
            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                //lista = bd.tb_vehiculo.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from m in bd.tb_vehiculo
                                  where m.serie_chasis.Contains(filtro) || m.serie_motor.Contains(filtro)
                                  select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorVehiculoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(VehiculoDbModel registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo serial del chasis
                    if (bd.tb_vehiculo.Where(x => x.serie_chasis.ToLower().Equals(registro.SerieChasis.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    MapeadorVehiculoDatos mapeador = new MapeadorVehiculoDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
                    bd.tb_vehiculo.Add(reg);
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
        public VehiculoDbModel BuscarRegistro(int id)
        {
            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                tb_vehiculo registro = bd.tb_vehiculo.Find(id);
                return new MapeadorVehiculoDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(VehiculoDbModel registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_vehiculo.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    MapeadorVehiculoDatos mapeador = new MapeadorVehiculoDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
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
                    tb_vehiculo registro = bd.tb_vehiculo.Find(id);
                    if (registro == null || registro.tb_ventas.Count() > 0)
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

        public bool EliminarRegistroFoto(int id)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    tb_fotos registro = bd.tb_fotos.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    registro.estado = false;
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

        public bool GuardarFotoVehiculo(FotoVehiculoDbModel dbModel)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    if (bd.tb_vehiculo.Where(x => x.id == dbModel.IdVehiculo).Count() > 0)
                    {
                        MapeadorFotoVehiculoDatos mapeador = new MapeadorFotoVehiculoDatos();
                        tb_fotos foto = mapeador.MapearTipo2Tipo1(dbModel);
                        bd.tb_fotos.Add(foto);
                        bd.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<FotoVehiculoDbModel> ListarFotosVehiculoPorId(int id)
        {
            using(ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                //var lista = bd.tb_fotos.Where(x => x.id_vehiculo == id).ToList();
                var lista = (from f in bd.tb_fotos
                              where f.id_vehiculo == id && f.estado
                              select f).ToList();
                MapeadorFotoVehiculoDatos mapeador = new MapeadorFotoVehiculoDatos();
                IEnumerable<FotoVehiculoDbModel> listaDbModel = mapeador.MapearTipo1Tipo2(lista);
                return listaDbModel;
            }
        }

    }
}
