using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Models;
using System.Net;

namespace ComputerStore.Controllers
{
    public class ManagerController : Controller
    {
        ComputerStoreEntities db = new ComputerStoreEntities();
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}