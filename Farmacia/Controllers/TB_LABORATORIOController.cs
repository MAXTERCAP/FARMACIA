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
    public class TB_LABORATORIOController : Controller
    {
        private BD_FARMACIAEntities3 db = new BD_FARMACIAEntities3();

        // GET: TB_LABORATORIO
        public ActionResult Index()
        {
            return View(db.TB_LABORATORIO.ToList());
        }

        // GET: TB_LABORATORIO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_LABORATORIO tB_LABORATORIO = db.TB_LABORATORIO.Find(id);
            if (tB_LABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_LABORATORIO);
        }

        // GET: TB_LABORATORIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_LABORATORIO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,descripcion,CUIT,direccion,contacto")] TB_LABORATORIO tB_LABORATORIO)
        {
            if (ModelState.IsValid)
            {
                db.TB_LABORATORIO.Add(tB_LABORATORIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_LABORATORIO);
        }

        // GET: TB_LABORATORIO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_LABORATORIO tB_LABORATORIO = db.TB_LABORATORIO.Find(id);
            if (tB_LABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_LABORATORIO);
        }

        // POST: TB_LABORATORIO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,descripcion,CUIT,direccion,contacto")] TB_LABORATORIO tB_LABORATORIO)
        {
            if (ModelState.IsValid)
            {
                tB_LABORATORIO.nombre = tB_LABORATORIO.nombre.Trim();
                db.Entry(tB_LABORATORIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_LABORATORIO);
        }

        // GET: TB_LABORATORIO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_LABORATORIO tB_LABORATORIO = db.TB_LABORATORIO.Find(id);
            if (tB_LABORATORIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_LABORATORIO);
        }

        // POST: TB_LABORATORIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TB_LABORATORIO tB_LABORATORIO = db.TB_LABORATORIO.Find(id);
            db.TB_LABORATORIO.Remove(tB_LABORATORIO);
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
