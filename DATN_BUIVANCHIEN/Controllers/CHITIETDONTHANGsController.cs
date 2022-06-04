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
    public class CHITIETDONTHANGsController : Controller
    {
        private QLbanDT db = new QLbanDT();

        // GET: CHITIETDONTHANGs
        public ActionResult Index()
        {
            var cHITIETDONTHANG = db.CHITIETDONTHANG.Include(c => c.DIENTHOAI).Include(c => c.DONDATHANG);
            return View(cHITIETDONTHANG.ToList());
        }

        // GET: CHITIETDONTHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONTHANG cHITIETDONTHANG = db.CHITIETDONTHANG.Find(id);
            if (cHITIETDONTHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONTHANG);
        }

        // GET: CHITIETDONTHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaDT = new SelectList(db.DIENTHOAI, "MaDT", "TenDT");
            ViewBag.MaDonHang = new SelectList(db.DONDATHANG, "MaDonHang", "MaDonHang");
            return View();
        }

        // POST: CHITIETDONTHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,MaDT,Soluong,Dongia")] CHITIETDONTHANG cHITIETDONTHANG)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDONTHANG.Add(cHITIETDONTHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDT = new SelectList(db.DIENTHOAI, "MaDT", "TenDT", cHITIETDONTHANG.MaDT);
            ViewBag.MaDonHang = new SelectList(db.DONDATHANG, "MaDonHang", "MaDonHang", cHITIETDONTHANG.MaDonHang);
            return View(cHITIETDONTHANG);
        }

        // GET: CHITIETDONTHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONTHANG cHITIETDONTHANG = db.CHITIETDONTHANG.Find(id);
            if (cHITIETDONTHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDT = new SelectList(db.DIENTHOAI, "MaDT", "TenDT", cHITIETDONTHANG.MaDT);
            ViewBag.MaDonHang = new SelectList(db.DONDATHANG, "MaDonHang", "MaDonHang", cHITIETDONTHANG.MaDonHang);
            return View(cHITIETDONTHANG);
        }

        // POST: CHITIETDONTHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,MaDT,Soluong,Dongia")] CHITIETDONTHANG cHITIETDONTHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDONTHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDT = new SelectList(db.DIENTHOAI, "MaDT", "TenDT", cHITIETDONTHANG.MaDT);
            ViewBag.MaDonHang = new SelectList(db.DONDATHANG, "MaDonHang", "MaDonHang", cHITIETDONTHANG.MaDonHang);
            return View(cHITIETDONTHANG);
        }

        // GET: CHITIETDONTHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONTHANG cHITIETDONTHANG = db.CHITIETDONTHANG.Find(id);
            if (cHITIETDONTHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONTHANG);
        }

        // POST: CHITIETDONTHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETDONTHANG cHITIETDONTHANG = db.CHITIETDONTHANG.Find(id);
            db.CHITIETDONTHANG.Remove(cHITIETDONTHANG);
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
