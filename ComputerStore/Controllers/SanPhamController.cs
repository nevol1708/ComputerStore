using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Models;

namespace ComputerStore.Controllers
{
    public class SanPhamController : Controller
    {
        ComputerStoreEntities db = new ComputerStoreEntities();

        // GET: ViewDetail
        public ActionResult ViewDetails(string _id)
        {
            ChiTietSP sanphamDC = db.ChiTietSPs.FirstOrDefault(m => m.MaSP == _id);
            if (sanphamDC == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanphamDC);
        }

        public ActionResult OrderBrand(string _idname)
        {
            ViewBag.nhasanxuats = db.ChiTietNSXes;
            ViewBag.sanphams = db.ChiTietSPs.Where(m => m.MaNSX.Contains(_idname));
            return View();
        }
        public ActionResult OrderPrice(int _min, int _max)
        {
            ViewBag.nhasanxuats = db.ChiTietNSXes;
            if (_max == 0)
            {
                ViewBag.sanphams = db.ChiTietSPs.Where(m => m.DonGia > _min);
                return View();
            }
            ViewBag.sanphams = db.ChiTietSPs.Where(m => m.DonGia > _min && m.DonGia < _max);
            return View();
        }
        public ActionResult OrderCPU(string _name)
        {
            ViewBag.nhasanxuats = db.ChiTietNSXes;
            ViewBag.sanphams = db.ChiTietSPs.Where(m => m.CPU.Contains(_name));
            return View();
        }
        public ActionResult OrderHDD(string _size)
        {
            ViewBag.nhasanxuats = db.ChiTietNSXes;
            ViewBag.sanphams = db.ChiTietSPs.Where(m => m.HDD.Contains(_size));
            return View();
        }
        public ActionResult OrderScreen(string _size)
        {
            ViewBag.nhasanxuats = db.ChiTietNSXes;
            ViewBag.sanphams = db.ChiTietSPs.Where(m => m.Screen.Contains(_size));
            return View();
        }
        public ActionResult OrderRAM(string _size)
        {
            ViewBag.nhasanxuats = db.ChiTietNSXes;
            ViewBag.sanphams = db.ChiTietSPs.Where(m => m.RAM.Contains(_size));
            return View();
        }
    }
}