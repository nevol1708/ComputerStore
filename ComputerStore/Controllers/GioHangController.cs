using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Models;
namespace ComputerStore.Controllers
{
    public class GioHangController : Controller
    {
        ComputerStoreEntities db = new ComputerStoreEntities();
        public ViewResult Index()
        {
            return View(Session["GioHang"]);
        }
        public List<GioHang> getCart()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        // them gio hang
        public RedirectResult addToCart(string sMaSanpham)
        {
            ChiTietSP sp = db.ChiTietSPs.Find(sMaSanpham);
            GioHang item = new GioHang()
            {
                sMaSP = sMaSanpham,
                sTenSP = sp.TenSP,
                iSoLuong = 1,
                dDonGia = (double)sp.DonGia,
                sAnhDaiDien = sp.Anh
            };
            if (Session["GioHang"] == null)
            {
                Session["GioHang"] = new List<GioHang>();
                (Session["GioHang"] as List<GioHang>).Add(item);
            }
            else
            {
                GioHang itemInCart = (Session["GioHang"] as List<GioHang>).SingleOrDefault(m => m.sMaSP == sMaSanpham);
                if (itemInCart != null)
                {
                    itemInCart.iSoLuong++;
                }
                else
                {
                    (Session["GioHang"] as List<GioHang>).Add(item);
                }
            }
            return Redirect(HttpContext.Request.UrlReferrer.ToString());
        }
        public JsonResult editCartItem(string sMaSanPham, short soLuongMoi)
        {
            GioHang itemInCart = null;
            try
            {
                itemInCart = (Session["GioHang"] as List<GioHang>).SingleOrDefault(m => m.sMaSP == sMaSanPham);
                itemInCart.iSoLuong = soLuongMoi;
                return Json(new { trangthai = 1, soluongmoi = soLuongMoi, thanhtienmoi = itemInCart.ThanhTien, tongsoluongmoi = (Session["GioHang"] as List<GioHang>).Sum(m => m.iSoLuong), tongthanhtienmoi = (Session["Giohang"] as List<GioHang>).Sum(m => m.ThanhTien) }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { trangthai = 0, soluongcu = itemInCart.iSoLuong }, JsonRequestBehavior.AllowGet);
            }
        }
        public RedirectToRouteResult deleteCartItem(string sMaSanPham)
        {
            (Session["GioHang"] as List<GioHang>).Remove((Session["GioHang"] as List<GioHang>).Single(m => m.sMaSP == sMaSanPham));
            return RedirectToAction("Index");
        }
    }
}