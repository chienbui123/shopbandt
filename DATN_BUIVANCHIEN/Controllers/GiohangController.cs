using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATN_BUIVANCHIEN.Models;
namespace DATN_BUIVANCHIEN.Controllers
{
    public class GiohangController : Controller
    { 
        QLbanDT db = new QLbanDT();
        //lấy giỏ hàng
        public List<Giohang> Laygiohang()
        {
           List<Giohang> IstGiohang = Session["Giohang"] as List<Giohang>;
            if(IstGiohang==null)
            {//Nếu giỏ hàng chưa tồn tại thì khởi tạo ListGiohang
                IstGiohang = new List<Giohang>();
                Session["Giohang"] = IstGiohang;
            }
            return IstGiohang;
        }
            
        // thêm hàng vào giỏ
        public ActionResult ThemGiohang(int iMaDT,string strURL)
        {//Lay ra session gio hang
            List<Giohang> IstGiohang = Laygiohang();
            //Kiem tra sach nay ton tai trong session["Giohang"] chua?
            Giohang sanpham = IstGiohang.Find(n => n.iMaDT == iMaDT);
            if(sanpham==null)
            {
                sanpham = new Giohang(iMaDT);
                IstGiohang.Add(sanpham);
                return Redirect(strURL);
           
            }
            else
            {
                sanpham.isoluong++;
                return Redirect(strURL);
            }
            return Redirect(strURL);
        }
        private int TongsoLuong()
        {
            int iTongsoLuong = 0;
            List<Giohang> IstGiohang = Session["Giohang"] as List<Giohang>;
            if(IstGiohang !=null)
            {
                iTongsoLuong = IstGiohang.Sum(n => n.isoluong);
            }
            return iTongsoLuong;
        }
        private double Tongtien()
        {
            double iTongtien = 0;
            List <Giohang> IstGiohang = Session["Giohang"] as List<Giohang>;
            if (IstGiohang != null)
            {
                iTongtien = IstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongtien;
        }
        public ActionResult Giohang()
        {
            List<Giohang> IstGiohang = Laygiohang();
            if(IstGiohang.Count==0)
            {
                return RedirectToAction("Index", "SmartphoneStore");
            }
            ViewBag.Tongsoluong = TongsoLuong();
            ViewBag.Tongtien = Tongtien();
            return View(IstGiohang);
        }
        //Xóa giỏ hàng
        public ActionResult XoaGiohang(int iMaSP)
        {
            List<Giohang> IstGiohang = Laygiohang();
            Giohang sanpham = IstGiohang.SingleOrDefault(n => n.iMaDT == iMaSP);
            if(sanpham != null)
            {
                IstGiohang.RemoveAll(n => n.iMaDT == iMaSP);
                return RedirectToAction("GioHang");
            }
            if(IstGiohang.Count==0)
            {
                return RedirectToAction("Index", "SmartphoneStore");
            }
            return RedirectToAction("GioHang");
        }
        //cap nhat gio hang
        public ActionResult CapnhatGiohang(int iMaSP,FormCollection f)
        {
            List<Giohang> IstGiohang = Laygiohang();
            Giohang sanpham = IstGiohang.SingleOrDefault(n => n.iMaDT == iMaSP);
            if(sanpham !=null)
            {
                sanpham.isoluong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        //xóa tất cả giỏ hàng
        public ActionResult XoaTatcaGiohang()
        {
            List<Giohang> IstGiohang = Laygiohang();
            IstGiohang.Clear();
            return RedirectToAction("Index", "SmartphoneStore");
        }
        [HttpGet]
      public ActionResult DatHang()
        {
            if(Session["Taikhoan"]==null||Session["Taikhoan"].ToString()=="")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }    
            if(Session["Giohang"]==null)
            {
                return RedirectToAction("Index", "SmartphoneStore");
            }
            List<Giohang> IstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongsoLuong();
            ViewBag.Tongtien = Tongtien();
            return View(IstGiohang);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection collection)
        {
           
           DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            List<Giohang> gh = Laygiohang();
            
            var Ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            if(String.IsNullOrEmpty(Ngaygiao))
            {
                ViewData["Loinhap"] = "vui lòng nhập ngày bạn muốn nhận hàng";
                return this.DatHang();
            }
            else
            {ddh.MaKH = kh.MaKH;
            ddh.Ngaydat = DateTime.Now;
                ddh.Ngaygiao = DateTime.Parse(Ngaygiao);

                ddh.Tinhtranggiaohang = false;
            ddh.Dathanhtoan = false; 
                db.DONDATHANG.Add(ddh);
            db.SaveChanges();
            foreach(var item in gh)
            {
                CHITIETDONTHANG ctdh = new CHITIETDONTHANG();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.MaDT = item.iMaDT;
                ctdh.Soluong = item.isoluong;
                ctdh.Dongia = (decimal)item.dDonggia;
                db.CHITIETDONTHANG.Add(ctdh);
            }
            db.SaveChanges();
            Session["Giohang"] = null;
           return RedirectToAction("Xacnhandonhang", "Giohang"); 
            }
            
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}