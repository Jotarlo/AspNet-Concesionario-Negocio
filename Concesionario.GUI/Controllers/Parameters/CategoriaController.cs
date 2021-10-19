using Concesionario.GUI.Helpers;
using Concesionario.GUI.Mapeadores.Parametros;
using Concesionario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Concesionario.GUI.Controllers.Parameters
{
    public class CategoriaController : Controller
    {
        private ImplCategoriaLogica acceso = new ImplCategoriaLogica();

        // GET: Categoria
        public ActionResult Index(String filtro = "")
        {
            IEnumerable<CategoriaDTO> listaDatos = acceso.ListarRegistros(String.Empty);
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            IEnumerable<ModeloCategoriaGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            return View(listaGUI);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO CategoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(CategoriaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO CategoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.EditarRegistro(CategoriaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = acceso.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id);
                if (CategoriaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
                return View(modelo);
            }
        }
    }

}

