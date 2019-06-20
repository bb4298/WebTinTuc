using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Controllers
{
    [Authorize(Users = "quangnguyen.4298@gmail.com")]
    [Authorize(Roles = "Admin")]
    public class NguoiDungModelsController : Controller
    {
        private WebTTDB db = new WebTTDB();

        // GET: NguoiDungModels
        public ActionResult Index()
        {
            return View(db.nguoiDungModels.ToList());
        }

        // GET: NguoiDungModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDungModels nguoiDungModels = db.nguoiDungModels.Find(id);
            if (nguoiDungModels == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDungModels);
        }

        // GET: NguoiDungModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NguoiDungModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NguoiDungID,HoTen,NgaySinh,DiaChi,Email,SDT,CMND,TrangThai")] NguoiDungModels nguoiDungModels)
        {
            if (ModelState.IsValid)
            {
                db.nguoiDungModels.Add(nguoiDungModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoiDungModels);
        }

        // GET: NguoiDungModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDungModels nguoiDungModels = db.nguoiDungModels.Find(id);
            if (nguoiDungModels == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDungModels);
        }

        // POST: NguoiDungModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NguoiDungID,HoTen,NgaySinh,DiaChi,Email,SDT,CMND,TrangThai")] NguoiDungModels nguoiDungModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDungModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoiDungModels);
        }

        // GET: NguoiDungModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDungModels nguoiDungModels = db.nguoiDungModels.Find(id);
            if (nguoiDungModels == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDungModels);
        }

        // POST: NguoiDungModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            

            NguoiDungModels nguoiDungModels = db.nguoiDungModels.Find(id);
            db.nguoiDungModels.Remove(nguoiDungModels);
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
