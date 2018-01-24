using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Models;

namespace ComputerStore.Controllers
{
    public class HomeController : Controller
    {
        private ComputerStoreEntities db = new ComputerStoreEntities();
        public ActionResult Index()
        {
            ViewBag.sanphams = db.ChiTietSPs;
            ViewBag.nhasanxuats = db.ChiTietNSXes;
            return View();
        }
    }
}