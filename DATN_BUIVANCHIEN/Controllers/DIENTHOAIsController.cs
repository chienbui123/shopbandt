using System;
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
    public class DIENTHOAIsController : Controller
    {
        private QLbanDT db = new QLbanDT();

        // GET: DIENTHOAIs
       
        public ActionResult Index(int? page,string searchString,string currentFilter)
        {if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurentFilter = searchString;
            var danhmuc = db.DIENTHOAI.Select(s => s);
            if(!String.IsNullOrEmpty(searchString))
            {
                danhmuc = danhmuc.Where(s => s.TenDT.Contains(searchString));
            }    
           danhmuc = danhmuc.OrderByDescending(s => s.Ngaycapnhat);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            return View(danhmuc.ToPagedList(pageNumber,pageSize));
        }

        // GET: DIENTHOAIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENTHOAI dIENTHOAI = db.DIENTHOAI.Find(id);
            if (dIENTHOAI == null)
            {
                return HttpNotFound();
            }
            return View(dIENTHOAI);
        }

        // GET: DIENTHOAIs/Create
        public ActionResult Create()
        {
            ViewBag.MaHDH = new SelectList(db.HDH, "MaHDH", "TenHDH");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB");
            return View();
        }

        // POST: DIENTHOAIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDT,TenDT,Giaban,Manhinh,Ram,Rom,cammera,Mota,Anhbia,Ngaycapnhat,Soluongton,MaHDH,MaNXB")] DIENTHOAI dIENTHOAI)
        {
            try
            {if (ModelState.IsValid)
            {
                dIENTHOAI.Anhbia = "";
                var f = Request.Files["ImageFile"];
                if(f !=null && f.ContentLength>0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/images" + FileName);
                    f.SaveAs(UploadPath);
                    dIENTHOAI.Anhbia = FileName;
                }
                db.DIENTHOAI.Add(dIENTHOAI);
                db.SaveChanges();
            }
return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "lỗi nhập dữ liệu" + ex.Message;
ViewBag.MaHDH = new SelectList(db.HDH, "MaHDH", "TenHDH", dIENTHOAI.MaHDH);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", dIENTHOAI.MaNXB);
            return View(dIENTHOAI);
            }

            
        }

        // GET: DIENTHOAIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENTHOAI dIENTHOAI = db.DIENTHOAI.Find(id);
            if (dIENTHOAI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDH = new SelectList(db.HDH, "MaHDH", "TenHDH", dIENTHOAI.MaHDH);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", dIENTHOAI.MaNXB);
            return View(dIENTHOAI);
        }

        // POST: DIENTHOAIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDT,TenDT,Giaban,Manhinh,Ram,Rom,cammera,Mota,Anhbia,Ngaycapnhat,Soluongton,MaHDH,MaNXB")] DIENTHOAI dIENTHOAI)
        {
            try
            { if (ModelState.IsValid)
            {
                    dIENTHOAI.Anhbia = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(UploadPath);
                        dIENTHOAI.Anhbia = FileName;
                    }

                    db.Entry(dIENTHOAI).State = EntityState.Modified;
                db.SaveChanges();
                
            }
return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi sửa dữ liệu!" + ex.Message;
  ViewBag.MaHDH = new SelectList(db.HDH, "MaHDH", "TenHDH", dIENTHOAI.MaHDH);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", dIENTHOAI.MaNXB);
            return View(dIENTHOAI);
            }
           
          
        }

        // GET: DIENTHOAIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENTHOAI dIENTHOAI = db.DIENTHOAI.Find(id);
            if (dIENTHOAI == null)
            {
                return HttpNotFound();
            }
            return View(dIENTHOAI);
        }

        // POST: DIENTHOAIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIENTHOAI dIENTHOAI = db.DIENTHOAI.Find(id);
            db.DIENTHOAI.Remove(dIENTHOAI);
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
