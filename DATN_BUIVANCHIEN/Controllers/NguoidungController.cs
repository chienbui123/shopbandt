using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;
namespace DATN_BUIVANCHIEN.Controllers
{
    public class NguoidungController : Controller
    {
        QLbanDT db = new QLbanDT();
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection,KHACHHANG kh)
        {
            var hoten = collection["HotenKH"];
             var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if(String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }    
            else if(String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "tên Đăng nhập không được để trống";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được để trống";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Mật khẩu nhập lại không được để trống";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi5"] = "Địa chỉ không được để trống";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi6"] = "Email không được để trống";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi7"] = "Số điện thoại không được để trống";
            }
            else if (String.IsNullOrEmpty(ngaysinh))
            {
                ViewData["Loi8"] = "ngày sinh không được để trống";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANG.Add(kh);
                db.SaveChanges();
            }
            return this.Dangky();
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
            var KhachHang = collection["Khachhang"];
            if(String.IsNullOrEmpty(tendn))
            { ViewData["Loi1"] = "phải nhập tên đăng nhập"; }
            else if(String.IsNullOrEmpty(matkhau))
            { ViewData["Loi2"] = "phải nhập Mật khẩu"; }
            else
            {
                KHACHHANG kh = db.KHACHHANG.SingleOrDefault(n => n.Taikhoan == tendn &&
                n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    Session["tk"] = kh.MaKH;
                    return RedirectToAction("Index", "SmartphoneStore");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
    }
}