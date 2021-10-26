using Concesionario.GUI.Helpers;
using Concesionario.GUI.Mapeadores.Vehiculo;
using Concesionario.GUI.Models.Vehiculo;
using LogicaNegocio.DTO.Vehiculo;
using LogicaNegocio.Implementacion.Vehiculo;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
    }
}
