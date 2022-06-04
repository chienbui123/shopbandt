using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;

namespace DATN_BUIVANCHIEN.Controllers
{
    public class HDHsController : Controller
    {
        private QLbanDT db = new QLbanDT();

        // GET: HDHs
        public ActionResult Index()
        {
            return View(db.HDH.ToList());
        }

        // GET: HDHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDH hDH = db.HDH.Find(id);
            if (hDH == null)
            {
                return HttpNotFound();
            }
            return View(hDH);
        }

        // GET: HDHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HDHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHDH,TenHDH")] HDH hDH)
        {
            if (ModelState.IsValid)
            {
                db.HDH.Add(hDH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hDH);
        }

        // GET: HDHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDH hDH = db.HDH.Find(id);
            if (hDH == null)
            {
                return HttpNotFound();
            }
            return View(hDH);
        }

        // POST: HDHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHDH,TenHDH")] HDH hDH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hDH);
        }

        // GET: HDHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDH hDH = db.HDH.Find(id);
            if (hDH == null)
            {
                return HttpNotFound();
            }
            return View(hDH);
        }

        // POST: HDHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HDH hDH = db.HDH.Find(id);
            try
            { db.HDH.Remove(hDH);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch(Exception ex)
            { ViewBag.Error = "Không Xóa hệ điều hành khi còn sản phẩm thuộc hệ điều hành đó!" + ex.Message;
                return View("Delete", hDH);
            }
           
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
