using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuongMaiDienTu.Models;

namespace ThuongMaiDienTu.Controllers
{
    public class CartController : Controller
    {
        THUONGMAIDIENTUEntities db = new THUONGMAIDIENTUEntities();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["Giohang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int iID_Product, string strURL)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sanpham = lstGiohang.Find(n => n.iID_Product == iID_Product);
            if (sanpham == null)
            {
                sanpham = new GioHang(iID_Product);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iQuantity++;
                return Redirect(strURL);
            }

        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iQuantity);
            }
            return iTongSoLuong;
        }
        public double TongSoTien()
        {
            double iTongSoTien = 0;
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return iTongSoTien;
        }
        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = Laygiohang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("KhongCoHang", "Cart");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongSoTien = TongSoTien();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongSoTien = TongSoTien();
            return PartialView();
        }
        public ActionResult XoaGioHang(int iMaSP)
        {
            PRODUCT dt = db.PRODUCTs.SingleOrDefault(n => n.IdProduct == iMaSP);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = Laygiohang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iID_Product == iMaSP);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iID_Product == iMaSP);
                return RedirectToAction("Cart");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            List<GioHang> lstGioHang = Laygiohang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("KhongCoHang","Cart");
            }
            return View(lstGioHang);
        }
        public ActionResult KhongCoHang()
        {
            return View();
        }

    }
}