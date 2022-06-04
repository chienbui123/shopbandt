using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;
namespace DATN_BUIVANCHIEN.Controllers
{
    public class AdminController : Controller
    {
        TaikhoanADM db = new TaikhoanADM();
        // GET: Admin
        public ActionResult Index()
        {
          
            return View();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            { ViewData["Loitk"] = "phải nhập tên đăng nhập"; }
            else if (String.IsNullOrEmpty(matkhau))
            { ViewData["Loink"] = "phải nhập Mật khẩu"; }
            else
            {
                Admin kh = db.Admin.SingleOrDefault(n => n.Taikhoan == tendn &&
                n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
    }
}