using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;
namespace DATN_BUIVANCHIEN.Controllers
{
    public class donhangController : Controller
    {
        QLbanDT db = new QLbanDT();
        // GET: donhang
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult donhang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            else
            {
                int khachhang = int.Parse(Session["tk"].ToString());
                var donhang = db.DONDATHANG.Where(n => n.MaKH == khachhang);
                donhang = donhang.OrderByDescending(s => s.Ngaydat);
                return View(donhang);
            }
        }
        public ActionResult chitietdonhang(int id)
        {

            var dt = from s in db.CHITIETDONTHANG
                     where s.MaDonHang == id
                     select s;

            return View(dt);

        }
    }
}