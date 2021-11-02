using Concesionario.GUI.Helpers;
using Concesionario.GUI.Mapeadores.Vehiculo;
using Concesionario.GUI.Models.Vehiculo;
using LogicaNegocio.DTO.Vehiculo;
using LogicaNegocio.Implementacion.Vehiculo;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Concesionario.GUI.Controllers.Vehiculo
{
    public class VehiculoController : Controller
    {
        private ImplVehiculoLogica logica = new ImplVehiculoLogica();

        // GET: Vehiculo
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<VehiculoDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            IEnumerable<ModeloVehiculoGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloVehiculoGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id.Value);
            if (VehiculoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            ModeloVehiculoGUI modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
            return View(modelo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloVehiculoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
                VehiculoDTO VehiculoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(VehiculoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id.Value);
            if (VehiculoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            ModeloVehiculoGUI modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
            return View(modelo);
        }

        // POST: Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloVehiculoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
                VehiculoDTO VehiculoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(VehiculoDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id.Value);
            if (VehiculoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            ModeloVehiculoGUI modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
            return View(modelo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id);
                if (VehiculoDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloVehiculoGUI modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
                return View(modelo);
            }
        }

        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloCargaImagenVehiculoGUI modelo = CrearModeloCargarImagenVehiculo(id);
            return View(modelo);
        }

        private ModeloCargaImagenVehiculoGUI CrearModeloCargarImagenVehiculo(int? id)
        {
            IEnumerable<FotoVehiculoDTO> listaDto = logica.ListarFotosVehiculoPorId(id.Value);
            MapeadorFotoVehiculoGUI mapeador = new MapeadorFotoVehiculoGUI();
            IEnumerable<ModeloFotoVehiculoGUI> listaFotos = mapeador.MapearTipo1Tipo2(listaDto);
            if (listaFotos == null)
            {
                listaFotos = new List<ModeloFotoVehiculoGUI>();
            }
            ModeloCargaImagenVehiculoGUI modelo = new ModeloCargaImagenVehiculoGUI()
            {
                Id = id.Value,
                ListadoImagenesVehiculo = listaFotos
            };
            return modelo;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(ModeloCargaImagenVehiculoGUI modelo)
        {
            try
            {
                if (modelo.Archivo.ContentLength > 0)
                {
                    try
                    {
                        DateTime ahora = DateTime.Now;
                        string fecha_nombre = String.Format("{0}_{1}_{2}_{3}_{4}_{5}", ahora.Day, ahora.Month, ahora.Year, ahora.Hour, ahora.Minute, ahora.Millisecond);
                        string nombreArchivo = String.Concat(fecha_nombre, "_", Path.GetFileName(modelo.Archivo.FileName));
                        string rutaCarpeta = DatosGenerales.RutaArchivosVehiculo;
                        string rutaCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreArchivo);
                        modelo.Archivo.SaveAs(rutaCompletaArchivo);
                        FotoVehiculoDTO dto = new FotoVehiculoDTO()
                        {
                            IdVehiculo = modelo.Id,
                            NombreFoto = nombreArchivo
                        };
                        logica.GuardarNombreFoto(dto);
                        // guardar nombre de archivo en base de datos
                        ViewBag.UploadFileMessage = "Archivo cargado correctamente.";
                        ModeloCargaImagenVehiculoGUI modeloView = CrearModeloCargarImagenVehiculo(modelo.Id);
                        return View(modeloView);
                    }
                    catch
                    {

                    }
                }
                ViewBag.UploadFileMessage = "Por favor seleccione al menos un archivo a cargar.";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.UploadFileMessage = "Error al cargar el archivo.";
                return View();
            }
        }

        public ActionResult EliminarFoto(int idFotoVehiculo, string nombreFotoVehiculo)
        {
            bool respuesta = logica.EliminarRegistroFoto(idFotoVehiculo);
            if (respuesta)
            {
                string rutaCarpeta = DatosGenerales.RutaArchivosVehiculo;
                string carpetaEliminados = DatosGenerales.CarpetaFotosVehiculoEliminadas;
                string rutaOrigenCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreFotoVehiculo);
                string rutaDestinoCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), carpetaEliminados, nombreFotoVehiculo);
                System.IO.File.Move(rutaOrigenCompletaArchivo, rutaDestinoCompletaArchivo);
            }
            return RedirectToAction("Index");
        }

    }
}
