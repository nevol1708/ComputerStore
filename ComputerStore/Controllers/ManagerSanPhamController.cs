using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Models;

namespace ComputerStore.Controllers
{
    public class ManagerSanPhamController : Controller
    {
        private ComputerStoreEntities db = new ComputerStoreEntities();

        // GET: ManagerSanPham
        public ActionResult Index()
        {
            var chiTietSPs = db.ChiTietSPs.Include(c => c.ChiTietNSX).Include(c => c.SanPham);
            return View(chiTietSPs.ToList());
        }

        // GET: ManagerSanPham/Details/5
        public ActionResult Details(string _id)
        {
            if (_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSP chiTietSP = db.ChiTietSPs.Find(_id);
            if (chiTietSP == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSP);
        }

        // GET: ManagerSanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaNSX = new SelectList(db.ChiTietNSXes, "MaNSX", "TenNSX");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP");
            return View();
        }

        // POST: ManagerSanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,MaNSX,CPU,RAM,HDD,Screen,DonGia")] ChiTietSP chiTietSP, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("", "Chưa chọn hình");
            }
            else
            {
                string extend = System.IO.Path.GetExtension(file.FileName);
                if (extend != ".jpg" && extend != ".jpeg" && extend != ".png")
                {
                    ModelState.AddModelError("", "Hình ảnh phải có đuôi .jpg hoặc .jpeg hoặc .png");
                }
                else
                {
                    chiTietSP.Anh = chiTietSP.MaSP + extend;
                    try
                    {
                        file.SaveAs(Server.MapPath("~/Content/Images/" + chiTietSP.Anh));
                    }
                    catch
                    {
                        ModelState.AddModelError("", "Xảy ra lỗi khi lưu hình");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                db.ChiTietSPs.Add(chiTietSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNSX = new SelectList(db.ChiTietNSXes, "MaNSX", "TenNSX", chiTietSP.MaNSX);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP", chiTietSP.MaSP);
            return View(chiTietSP);
        }

        // GET: ManagerSanPham/Edit/5
        public ActionResult Edit(string _id)
        {
            if (_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSP chiTietSP = db.ChiTietSPs.Find(_id);
            if (chiTietSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNSX = new SelectList(db.ChiTietNSXes, "MaNSX", "TenNSX", chiTietSP.MaNSX);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP", chiTietSP.MaSP);
            return View(chiTietSP);
        }

        // POST: ManagerSanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,MaNSX,CPU,RAM,HDD,Screen,DonGia")] ChiTietSP chiTietSP, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("", "Chưa chọn hình");
            }
            else
            {
                string extend = System.IO.Path.GetExtension(file.FileName);
                if (extend != ".jpg" && extend != ".jpeg" && extend != ".png")
                {
                    ModelState.AddModelError("", "Hình ảnh phải có đuôi .jpg hoặc .jpeg hoặc .png");
                }
                else
                {
                    chiTietSP.Anh = chiTietSP.MaSP + extend;
                    try
                    {
                        file.SaveAs(Server.MapPath("~/Content/Images/" + chiTietSP.Anh));
                    }
                    catch
                    {
                        ModelState.AddModelError("", "Xảy ra lỗi khi lưu hình");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(chiTietSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNSX = new SelectList(db.ChiTietNSXes, "MaNSX", "TenNSX", chiTietSP.MaNSX);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP", chiTietSP.MaSP);
            return View(chiTietSP);
        }

        // GET: ManagerSanPham/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSP chiTietSP = db.ChiTietSPs.Find(id);
            if (chiTietSP == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSP);
        }

        // POST: ManagerSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietSP chiTietSP = db.ChiTietSPs.Find(id);
            db.ChiTietSPs.Remove(chiTietSP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
