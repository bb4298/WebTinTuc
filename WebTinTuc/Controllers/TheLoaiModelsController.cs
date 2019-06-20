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
    public class TheLoaiModelsController : Controller
    {
        private WebTTDB db = new WebTTDB();

        // GET: TheLoaiModels
        public ActionResult Index()
        {
            return View(db.theLoaiModels.ToList());
        }

        // GET: TheLoaiModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoaiModels theLoaiModels = db.theLoaiModels.Find(id);
            if (theLoaiModels == null)
            {
                return HttpNotFound();
            }
            return View(theLoaiModels);
        }

        // GET: TheLoaiModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TheLoaiModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TheLoaiID,TenTheLoai,MoTa")] TheLoaiModels theLoaiModels)
        {
            if (ModelState.IsValid)
            {
                db.theLoaiModels.Add(theLoaiModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theLoaiModels);
        }

        // GET: TheLoaiModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoaiModels theLoaiModels = db.theLoaiModels.Find(id);
            if (theLoaiModels == null)
            {
                return HttpNotFound();
            }
            return View(theLoaiModels);
        }

        // POST: TheLoaiModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TheLoaiID,TenTheLoai,MoTa")] TheLoaiModels theLoaiModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theLoaiModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theLoaiModels);
        }

        // GET: TheLoaiModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoaiModels theLoaiModels = db.theLoaiModels.Find(id);
            if (theLoaiModels == null)
            {
                return HttpNotFound();
            }
            return View(theLoaiModels);
        }

        // POST: TheLoaiModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheLoaiModels theLoaiModels = db.theLoaiModels.Find(id);
            db.theLoaiModels.Remove(theLoaiModels);
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
