using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Farmacia.Models;

namespace Farmacia.Controllers
{
    public class TB_MEDICAMENTOSController : Controller
    {
        private BD_FARMACIAEntities db = new BD_FARMACIAEntities();

        // GET: TB_MEDICAMENTOS
        public ActionResult Index()
        {
            return View(db.TB_MEDICAMENTOS.ToList());
        }

        // GET: TB_MEDICAMENTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_MEDICAMENTOS tB_MEDICAMENTOS = db.TB_MEDICAMENTOS.Find(id);
            if (tB_MEDICAMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tB_MEDICAMENTOS);
        }

        // GET: TB_MEDICAMENTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_MEDICAMENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,CANTIDAD,PRECIO")] TB_MEDICAMENTOS tB_MEDICAMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.TB_MEDICAMENTOS.Add(tB_MEDICAMENTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_MEDICAMENTOS);
        }

        // GET: TB_MEDICAMENTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_MEDICAMENTOS tB_MEDICAMENTOS = db.TB_MEDICAMENTOS.Find(id);
            if (tB_MEDICAMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tB_MEDICAMENTOS);
        }

        // POST: TB_MEDICAMENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,CANTIDAD,PRECIO")] TB_MEDICAMENTOS tB_MEDICAMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_MEDICAMENTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_MEDICAMENTOS);
        }

        // GET: TB_MEDICAMENTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_MEDICAMENTOS tB_MEDICAMENTOS = db.TB_MEDICAMENTOS.Find(id);
            if (tB_MEDICAMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tB_MEDICAMENTOS);
        }

        // POST: TB_MEDICAMENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_MEDICAMENTOS tB_MEDICAMENTOS = db.TB_MEDICAMENTOS.Find(id);
            db.TB_MEDICAMENTOS.Remove(tB_MEDICAMENTOS);
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
