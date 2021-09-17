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
    public class MarcaController : Controller
    {
        private ConcesionarioBDEntities db = new ConcesionarioBDEntities();

        // GET: Marca
        public ActionResult Index()
        {
            using (ConcesionarioBDEntities baseDeDatos = new ConcesionarioBDEntities())
            {
                return View(baseDeDatos.tb_marca.ToList());
            }
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = db.tb_marca.Find(id);
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
                db.tb_marca.Add(tb_marca);
                db.SaveChanges();
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
            tb_marca tb_marca = db.tb_marca.Find(id);
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
                db.Entry(tb_marca).State = EntityState.Modified;
                db.SaveChanges();
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
            tb_marca tb_marca = db.tb_marca.Find(id);
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
            tb_marca tb_marca = db.tb_marca.Find(id);
            db.tb_marca.Remove(tb_marca);
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
