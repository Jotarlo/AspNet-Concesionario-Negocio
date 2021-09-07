using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Concesionario.GUI.ModeloBD;

namespace Concesionario.GUI.Controllers.Parameters
{
    public class ProveedorController : Controller
    {
        private ConcesionarioBDEntities db = new ConcesionarioBDEntities();

        // GET: Proveedor
        public ActionResult Index()
        {
            return View(db.tb_proveedor.ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_proveedor tb_proveedor = db.tb_proveedor.Find(id);
            if (tb_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(tb_proveedor);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,razon_social,direccion,telefono,correo")] tb_proveedor tb_proveedor)
        {
            if (ModelState.IsValid)
            {
                db.tb_proveedor.Add(tb_proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_proveedor);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_proveedor tb_proveedor = db.tb_proveedor.Find(id);
            if (tb_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(tb_proveedor);
        }

        // POST: Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,razon_social,direccion,telefono,correo")] tb_proveedor tb_proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_proveedor);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_proveedor tb_proveedor = db.tb_proveedor.Find(id);
            if (tb_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(tb_proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_proveedor tb_proveedor = db.tb_proveedor.Find(id);
            db.tb_proveedor.Remove(tb_proveedor);
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
