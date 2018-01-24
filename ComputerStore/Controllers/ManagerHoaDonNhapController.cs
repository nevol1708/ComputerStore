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
    public class ManagerHoaDonNhapController : Controller
    {
        private ComputerStoreEntities db = new ComputerStoreEntities();

        // GET: ManagerHoaDonNhap
        public ActionResult Index()
        {
            var hoaDonNhaps = db.HoaDonNhaps.Include(h => h.ChiTietNhaPhanPhoi).Include(h => h.NhanVien);
            return View(hoaDonNhaps.ToList());
        }

        // GET: ManagerHoaDonNhap/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonNhap);
        }

        // GET: ManagerHoaDonNhap/Create
        public ActionResult Create()
        {
            ViewBag.MaNPP = new SelectList(db.ChiTietNhaPhanPhois, "MaNPP", "TenNPP");
            ViewBag.NhanVienNhap = new SelectList(db.NhanViens, "MaNV", "TenNhanVien");
            return View();
        }

        // POST: ManagerHoaDonNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaNPP,NhanVienNhap")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonNhaps.Add(hoaDonNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNPP = new SelectList(db.ChiTietNhaPhanPhois, "MaNPP", "TenNPP", hoaDonNhap.MaNPP);
            ViewBag.NhanVienNhap = new SelectList(db.NhanViens, "MaNV", "TenNhanVien", hoaDonNhap.NhanVienNhap);
            return View(hoaDonNhap);
        }

        // GET: ManagerHoaDonNhap/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNPP = new SelectList(db.ChiTietNhaPhanPhois, "MaNPP", "TenNPP", hoaDonNhap.MaNPP);
            ViewBag.NhanVienNhap = new SelectList(db.NhanViens, "MaNV", "TenNhanVien", hoaDonNhap.NhanVienNhap);
            return View(hoaDonNhap);
        }

        // POST: ManagerHoaDonNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaNPP,NhanVienNhap")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNPP = new SelectList(db.ChiTietNhaPhanPhois, "MaNPP", "TenNPP", hoaDonNhap.MaNPP);
            ViewBag.NhanVienNhap = new SelectList(db.NhanViens, "MaNV", "TenNhanVien", hoaDonNhap.NhanVienNhap);
            return View(hoaDonNhap);
        }

        // GET: ManagerHoaDonNhap/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonNhap);
        }

        // POST: ManagerHoaDonNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            db.HoaDonNhaps.Remove(hoaDonNhap);
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
