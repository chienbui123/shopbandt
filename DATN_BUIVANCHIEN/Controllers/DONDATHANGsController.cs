﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;
using PagedList;
namespace DATN_BUIVANCHIEN.Controllers
{
    public class DONDATHANGsController : Controller
    {
        private QLbanDT db = new QLbanDT();

        // GET: DONDATHANGs
        
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            

            var danhmuc = db.DONDATHANG.Select(s => s);
        
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            danhmuc = danhmuc.OrderByDescending(s => s.Ngaydat);
            return View(danhmuc.ToPagedList(pageNumber, pageSize));
        }

        // GET: DONDATHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANG.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }
      
        public ActionResult chitietdonhang(int id)
        {
            
            var dt = from s in db.CHITIETDONTHANG
                     where s.MaDonHang == id
                     select s;
           
            return View(dt);

        }
       
      
        // GET: DONDATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "HoTen");
            return View();
        }

        // POST: DONDATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,Dathanhtoan,Tinhtranggiaohang,Ngaydat,Ngaygiao,MaKH")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONDATHANG.Add(dONDATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "HoTen", dONDATHANG.MaKH);
            return View(dONDATHANG);
        }

        // GET: DONDATHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANG.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "HoTen", dONDATHANG.MaKH);
            return View(dONDATHANG);
        }

        // POST: DONDATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,Dathanhtoan,Tinhtranggiaohang,Ngaydat,Ngaygiao,MaKH")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANG, "MaKH", "HoTen", dONDATHANG.MaKH);
            return View(dONDATHANG);
        }

        // GET: DONDATHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANG.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }

        // POST: DONDATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONDATHANG dONDATHANG = db.DONDATHANG.Find(id);
            db.DONDATHANG.Remove(dONDATHANG);
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
