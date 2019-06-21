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
    public class CommentModelsController : Controller
    {
        private WebTTDB db = new WebTTDB();

        // GET: CommentModels
        public ActionResult Index(int? id)
        {
            var commentModels = db.commentModels.Include(c => c.BaiVietModels).Include(c => c.NguoiDungModels).Where(c => c.BaiVietModels.BaiVietID == id);
            ViewBag.tenBaiViet = db.baiVietModels.Where(c => c.BaiVietID == id).Select(c=>c.TieuDe).FirstOrDefault().ToString();
            return View(commentModels.ToList());
        }

        // GET: CommentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModels commentModels = db.commentModels.Find(id);
            if (commentModels == null)
            {
                return HttpNotFound();
            }
            return View(commentModels);
        }

        // GET: CommentModels/Create
        public ActionResult Create()
        {
            ViewBag.BaiVietID = new SelectList(db.baiVietModels, "BaiVietID", "TieuDe");
            ViewBag.NguoiDungID = new SelectList(db.nguoiDungModels, "NguoiDungID", "HoTen");
            return View();
        }

        // POST: CommentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CmtID,NoiDung,NgayCmt,TrangThaiDuyet,BaiVietID,NguoiDungID")] CommentModels commentModels)
        {
            if (ModelState.IsValid)
            {
                db.commentModels.Add(commentModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BaiVietID = new SelectList(db.baiVietModels, "BaiVietID", "TieuDe", commentModels.BaiVietID);
            ViewBag.NguoiDungID = new SelectList(db.nguoiDungModels, "NguoiDungID", "HoTen", commentModels.NguoiDungID);
            return View(commentModels);
        }

        // GET: CommentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModels commentModels = db.commentModels.Find(id);
            if (commentModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.BaiVietID = new SelectList(db.baiVietModels, "BaiVietID", "TieuDe", commentModels.BaiVietID);
            ViewBag.NguoiDungID = new SelectList(db.nguoiDungModels, "NguoiDungID", "HoTen", commentModels.NguoiDungID);
            return View(commentModels);
        }

        // POST: CommentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CmtID,NoiDung,NgayCmt,TrangThaiDuyet,BaiVietID,NguoiDungID")] CommentModels commentModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BaiVietID = new SelectList(db.baiVietModels, "BaiVietID", "TieuDe", commentModels.BaiVietID);
            ViewBag.NguoiDungID = new SelectList(db.nguoiDungModels, "NguoiDungID", "HoTen", commentModels.NguoiDungID);
            return View(commentModels);
        }

        // GET: CommentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModels commentModels = db.commentModels.Find(id);
            if (commentModels == null)
            {
                return HttpNotFound();
            }
            return View(commentModels);
        }

        // POST: CommentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentModels commentModels = db.commentModels.Find(id);
            db.commentModels.Remove(commentModels);
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
