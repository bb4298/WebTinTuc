using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebTinTuc.Models
{
    public class WebTTDB:DbContext
    {
        public WebTTDB() : base("WebTTDB")
        {

        }
        public DbSet<NguoiDungModels> nguoiDungModels { get; set; }
        public DbSet<BaiVietModels> baiVietModels { get; set; }
        public DbSet<TheLoaiModels> theLoaiModels { get; set; }
        public DbSet<CommentModels> commentModels { get; set; }
    }
}