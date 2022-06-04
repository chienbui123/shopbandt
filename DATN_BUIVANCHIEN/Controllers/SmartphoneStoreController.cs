using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;
namespace DATN_BUIVANCHIEN.Controllers
{
    public class SmartphoneStoreController : Controller
    {
        QLbanDT db = new QLbanDT();
        private List<DIENTHOAI> LatDTmoi(int count)
        {
            return db.DIENTHOAI.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        // GET: SmartphoneStore
        public ActionResult Index()
        {var DTmoi = LatDTmoi(8);
         
            return View(DTmoi);
        }
        public ActionResult timkiem(string searchString,string to,string nho)
        {
            var DIENTHOAI = db.DIENTHOAI.Select(p => p);
            if (!String.IsNullOrEmpty(searchString))
            {
                DIENTHOAI = DIENTHOAI.Where(p => p.TenDT.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(to) && !String.IsNullOrEmpty(nho))
            {
                int a = int.Parse(nho);
                int b = int.Parse(to);
                return View(db.DIENTHOAI.Where(p => p.Giaban <= b && p.Giaban >= a && p.TenDT.Contains(searchString)));

            }
            return View(DIENTHOAI.Take(30).ToList());
        }
        public ActionResult dtmoi()
        {
            var DTmoi = LatDTmoi(50);

            return View(DTmoi);
        }
        public ActionResult DTgiare()
        {
            var re = db.DIENTHOAI.Where(p => p.Giaban >= 0 && p.Giaban<=4000000).ToList();
            return View(re);
        }
        public ActionResult DTtrungcap()
        {
            var re = db.DIENTHOAI.Where(p => p.Giaban >= 4000001 && p.Giaban <= 14000000).ToList();
            return View(re);
        }
        public ActionResult DTcaocap()
        {
            var re = db.DIENTHOAI.Where(p => p.Giaban >= 14000001 ).ToList();
            return View(re);
        }
        public ActionResult iphone()
        { var ip = db.DIENTHOAI.Where(p => p.MaNXB == 2).ToList();
            return View(ip);
        }
        public ActionResult samsung()
        {
            var ss = db.DIENTHOAI.Where(p => p.MaNXB == 1).ToList();
            return View(ss);
        }
        public ActionResult oppo()
        {
            var op = db.DIENTHOAI.Where(p => p.MaNXB == 3).ToList();
            return View(op);
        }
        public ActionResult xiaomi()
        {
            var mi = db.DIENTHOAI.Where(p => p.MaNXB == 4).ToList();
            return View(mi);
        }
        public ActionResult dtiphone()
        {
            var ip = db.DIENTHOAI.Where(n => n.MaNXB == 2).Take(4).ToList();
            return PartialView(ip);
        }
        public ActionResult dtsamsung()
        {
            var ss = db.DIENTHOAI.Where(n => n.MaNXB == 1).Take(4).ToList();
            return PartialView(ss);
        }
        public ActionResult dtxiaomi()
        {
            var mi = db.DIENTHOAI.Where(n => n.MaNXB == 4).Take(4).ToList();
            return PartialView(mi);
        }
        public ActionResult dtoppo()
        {
            var mi = db.DIENTHOAI.Where(n => n.MaNXB == 3).Take(4).ToList();
            return PartialView(mi);
        }


        public ActionResult Details(int id)
        {
            var dt = from s in db.DIENTHOAI
                     where s.MaDT == id
                     select s;
            return View(dt.Single());
        }
    }
}