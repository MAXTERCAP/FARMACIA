using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Farmacia.Models;

using System.Configuration;     //   CUSTOM - agregar si se regenera el controlador
using System.Data.SqlClient;    //   CUSTOM - agregar si se regenera el controlador

namespace Farmacia.Controllers
{
    public class TB_MEDICAMENTOS1Controller : Controller
    {
        private BD_FARMACIAEntities3 db = new BD_FARMACIAEntities3();

        // GET: TB_MEDICAMENTOS1
        public ActionResult Index()
        {
            return View(db.TB_MEDICAMENTOS.ToList());
        }

        // GET: TB_MEDICAMENTOS1/Details/5
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

        // GET: TB_MEDICAMENTOS1/Create
        public ActionResult Create()
        {
            ViewBag.PresentacionList = ToSelectList(GetValuesFromTable("TB_PRESENTACION_LIST"), "nombre", "nombre"); //   CUSTOM - agregar si se regenera el controlador
            ViewBag.LaboratorioList  = ToSelectList(GetValuesFromTable("TB_LABORATORIO"),       "nombre", "nombre"); //   CUSTOM - agregar si se regenera el controlador
            return View();
        }

        // POST: TB_MEDICAMENTOS1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,CANTIDAD,PRECIO,GRAMAJE,TIPO_PASTILLAS,DOBLE_RECETA,PRESENTACION,LABORATORIO")] TB_MEDICAMENTOS tB_MEDICAMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.TB_MEDICAMENTOS.Add(tB_MEDICAMENTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_MEDICAMENTOS);
        }

        // GET: TB_MEDICAMENTOS1/Edit/5
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
            ViewBag.PresentacionList = ToSelectList(GetValuesFromTable("TB_PRESENTACION_LIST"), "nombre", "nombre"); //   CUSTOM - agregar si se regenera el controlador
            ViewBag.LaboratorioList  = ToSelectList(GetValuesFromTable("TB_LABORATORIO"),       "nombre", "nombre"); //   CUSTOM - agregar si se regenera el controlador
            return View(tB_MEDICAMENTOS);
        }

        // POST: TB_MEDICAMENTOS1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,CANTIDAD,PRECIO,GRAMAJE,TIPO_PASTILLAS,DOBLE_RECETA,PRESENTACION,LABORATORIO")] TB_MEDICAMENTOS tB_MEDICAMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_MEDICAMENTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_MEDICAMENTOS);
        }

        // GET: TB_MEDICAMENTOS1/Delete/5
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

        // POST: TB_MEDICAMENTOS1/Delete/5
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

        //
        // A partir de aca, es codigo CUSTOM que debe ser AGREGADO si se regenera el controlador
        //
        [NonAction]
        public DataTable GetValuesFromTable(string table)
        {
            string constr = ConfigurationManager.ConnectionStrings["BD_FARMACIAEntities2"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select nombre From [BD_FARMACIA].[dbo].["+table+"];", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            return _dt;
        }
        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }
            return new SelectList(list, "Value", "Text");
        }

    }
}
