using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Concesionario.GUI.Controllers.Vehiculo
{
    public class VehiculoController : Controller
    {
        private ConcesionarioBDEntities db = new ConcesionarioBDEntities();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var tb_vehiculo = db.tb_vehiculo.Include(t => t.tb_categoria).Include(t => t.tb_marca).Include(t => t.tb_proveedor);
            return View(tb_vehiculo.ToList());
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vehiculo tb_vehiculo = db.tb_vehiculo.Find(id);
            if (tb_vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tb_vehiculo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre");
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre");
            ViewBag.id_proveedor = new SelectList(db.tb_proveedor, "id", "razon_social");
            return View();
        }

        // POST: Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,color,modelo,serie_chasis,serie_motor,id_marca,id_categoria,precio,descuento,estado,id_proveedor")] tb_vehiculo tb_vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.tb_vehiculo.Add(tb_vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre", tb_vehiculo.id_categoria);
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre", tb_vehiculo.id_marca);
            ViewBag.id_proveedor = new SelectList(db.tb_proveedor, "id", "razon_social", tb_vehiculo.id_proveedor);
            return View(tb_vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vehiculo tb_vehiculo = db.tb_vehiculo.Find(id);
            if (tb_vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre", tb_vehiculo.id_categoria);
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre", tb_vehiculo.id_marca);
            ViewBag.id_proveedor = new SelectList(db.tb_proveedor, "id", "razon_social", tb_vehiculo.id_proveedor);
            return View(tb_vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,color,modelo,serie_chasis,serie_motor,id_marca,id_categoria,precio,descuento,estado,id_proveedor")] tb_vehiculo tb_vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre", tb_vehiculo.id_categoria);
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre", tb_vehiculo.id_marca);
            ViewBag.id_proveedor = new SelectList(db.tb_proveedor, "id", "razon_social", tb_vehiculo.id_proveedor);
            return View(tb_vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vehiculo tb_vehiculo = db.tb_vehiculo.Find(id);
            if (tb_vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tb_vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_vehiculo tb_vehiculo = db.tb_vehiculo.Find(id);
            db.tb_vehiculo.Remove(tb_vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
