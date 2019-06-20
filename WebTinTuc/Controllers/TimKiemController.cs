using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using WebTinTuc.Models;

namespace WebTinTuc.Controllers
{
    public class TimKiemController : Controller
    {
        WebTTDB db = new WebTTDB();
        // GET: TimKiem
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TimTheoTieuDe()
        {
            var baiVietModels = db.baiVietModels.Include(b => b.TheLoaiModels);
            return View(baiVietModels.ToList());
        }

        [HttpPost]
        public ActionResult TimTheoTieuDe(String searchString)
        {
            var links = from l in db.baiVietModels // lấy toàn bộ liên kết
                        select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.TieuDe.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            return View(links.ToList()); //trả về kết quả


        }
    }
}