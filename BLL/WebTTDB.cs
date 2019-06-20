using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class WebTTDB
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
