using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;
using PagedList;

namespace WebTinTuc.Controllers
{
    public class BaiVietModelsController : Controller
    {
        private WebTTDB db = new WebTTDB();

        // GET: BaiVietModels
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in db.baiVietModels
                         select l).OrderBy(x => x.BaiVietID);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                return RedirectToAction("IndexAdmin", "BaiVietModels");

                
                // 5. Trả về các Link được phân trang theo kích thước và số trang.
                // var baiVietModels = db.baiVietModels.Include(b => b.TheLoaiModels);
                return View(db.baiVietModels.OrderByDescending(i=>i.NgayDang).ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Users = "quangnguyen.4298@gmail.com")]
        public ActionResult IndexAdmin(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in db.baiVietModels
                         select l).OrderBy(x => x.BaiVietID);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            // var baiVietModels = db.baiVietModels.Include(b => b.TheLoaiModels);
            return View(db.baiVietModels.OrderByDescending(i => i.NgayDang).ToPagedList(pageNumber, pageSize));
        }

        // GET: BaiVietModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietModels baiVietModels = db.baiVietModels.Find(id);
            baiVietModels.LuotXem = baiVietModels.LuotXem + 1;
            db.Entry(baiVietModels).State = EntityState.Modified;
            db.SaveChanges();
            if (baiVietModels == null)
            {
                return HttpNotFound();
            }
            return View(baiVietModels);
        }

        // GET: BaiVietModels/Create
        [Authorize(Users = "quangnguyen.4298@gmail.com")]
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.TheLoaiID = new SelectList(db.theLoaiModels, "TheLoaiID", "TenTheLoai");
            return View();
        }

        // POST: BaiVietModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "quangnguyen.4298@gmail.com")]
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BaiVietID,TieuDe,Anh,NgayDang,MoTa,NoiDung,TrangThaiHienThi,LuotXem,TheLoaiID,NguoiDungID")] BaiVietModels baiVietModels)
        {
            if (ModelState.IsValid)
            {
               
                db.baiVietModels.Add(baiVietModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TheLoaiID = new SelectList(db.theLoaiModels, "TheLoaiID", "TenTheLoai", baiVietModels.TheLoaiID);
            return View(baiVietModels);
        }

        // GET: BaiVietModels/Edit/5
        [Authorize(Users = "quangnguyen.4298@gmail.com")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietModels baiVietModels = db.baiVietModels.Find(id);
            if (baiVietModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.TheLoaiID = new SelectList(db.theLoaiModels, "TheLoaiID", "TenTheLoai", baiVietModels.TheLoaiID);
            return View(baiVietModels);
        }

        // POST: BaiVietModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "quangnguyen.4298@gmail.com")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BaiVietID,TieuDe,Anh,NgayDang,MoTa,NoiDung,TrangThaiHienThi,LuotXem,TheLoaiID,NguoiDungID")] BaiVietModels baiVietModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiVietModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TheLoaiID = new SelectList(db.theLoaiModels, "TheLoaiID", "TenTheLoai", baiVietModels.TheLoaiID);
            return View(baiVietModels);
        }

        // GET: BaiVietModels/Delete/5
        [Authorize(Users = "quangnguyen.4298@gmail.com")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietModels baiVietModels = db.baiVietModels.Find(id);
            if (baiVietModels == null)
            {
                return HttpNotFound();
            }
            return View(baiVietModels);
        }

        // POST: BaiVietModels/Delete/5
        [Authorize(Users = "quangnguyen.4298@gmail.com")]
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiVietModels baiVietModels = db.baiVietModels.Find(id);
            db.baiVietModels.Remove(baiVietModels);
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
