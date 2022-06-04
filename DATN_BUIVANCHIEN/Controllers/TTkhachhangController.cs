using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;
namespace DATN_BUIVANCHIEN.Controllers
{
    public class TTkhachhangController : Controller
    {
        QLbanDT db = new QLbanDT();
        // GET: TTkhachhang
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult xemthongtinkhachhang()
        {
           
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            else { 
            int khachhang = int.Parse(Session["tk"].ToString());
            var khachHang = db.KHACHHANG.Where(n => n.MaKH == khachhang).FirstOrDefault();

            return View(khachHang);
            }

            
           
           
        }
        [HttpPost]
        public ActionResult xemthongtinkhachhang(KHACHHANG obj)
        {
            try
            {   obj.MaKH = int.Parse(Session["tk"].ToString());
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dangnhap", "Nguoidung");

            }
             

             catch (Exception ex)
            {
                ViewBag.Error = "lỗi nhập dữ liệu hoặc tên tài khoản đã có người đăng kí" + ex.Message;
                return View("xemthongtinkhachhang");
            }

        }
    }

}