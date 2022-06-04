using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATN_BUIVANCHIEN.Models;
namespace DATN_BUIVANCHIEN.Models
{
    public class Giohang
    {
        QLbanDT db = new QLbanDT();

        public int iMaDT { set; get; }
        public string sTenDT { set; get; }
        public string sAnhbia { set; get; }
        public Double dDonggia { set; get; }
        public int isoluong  { set; get; }
        public Double dThanhtien
        {
            get { return isoluong * dDonggia; }
        }
        public Giohang(int MaDT)
        {
            iMaDT = MaDT;
            DIENTHOAI dienthoai = db.DIENTHOAI.Single(n => n.MaDT == iMaDT);
            sTenDT = dienthoai.TenDT;
            sAnhbia = dienthoai.Anhbia;
            dDonggia = double.Parse(dienthoai.Giaban.ToString());
            isoluong = 1;
        }
    }
}