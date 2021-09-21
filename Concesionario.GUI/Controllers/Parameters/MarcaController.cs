using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.Implementacion.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using Concesionario.GUI.Models.Parametros;

namespace Concesionario.GUI.Controllers.Parameters
{
    public class MarcaController : Controller
    {
        private ImplMarcaDatos acceso = new ImplMarcaDatos();

        // GET: Marca
        public ActionResult Index(String filtro = "")
        {
            IEnumerable<tb_marca> listaDatos = acceso.ListarRegistros(String.Empty);
            IList<ModeloMarcaGUI> listaGUI = new List<ModeloMarcaGUI>();
            foreach (var item in listaDatos)
            {
                listaGUI.Add(new ModeloMarcaGUI{
                    Id = item.id,
                    Nombre = item.nombre
                });
            }

            return View(listaGUI);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = acceso.BuscarRegistro(id.Value);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_marca tb_marca)
        {
            if (ModelState.IsValid)
            {
                acceso.GuardarRegistro(tb_marca);
                return RedirectToAction("Index");
            }

            return View(tb_marca);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = acceso.BuscarRegistro(id.Value);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_marca tb_marca)
        {
            if (ModelState.IsValid)
            {
                acceso.EditarRegistro(tb_marca);
                return RedirectToAction("Index");
            }
            return View(tb_marca);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = acceso.BuscarRegistro(id.Value);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acceso.EliminarRegistro(id);
            return RedirectToAction("Index");
        }
    }

}
