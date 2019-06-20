using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTinTuc.Models
{
    public class BaiVietModels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int BaiVietID { get; set; }

        [Required]
        [DisplayName("Tiêu Đề")]
        public string TieuDe { get; set; }

        [DisplayName("Ảnh")]
        public string Anh { get; set; }
     
        [Required]
        [DisplayName("Ngày Đăng")]
        public DateTime NgayDang { get; set; }

        [Required]
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }

        [AllowHtml]
        [Required]
        [DisplayName("Nội Dung")]
        public string NoiDung { get; set; }

        [Required]
        [DisplayName("Trạng Thái Hiển Thị")]
        public bool TrangThaiHienThi { get; set; }

        [Required]
        [DisplayName("Lượt Xem")]
        public int LuotXem { get; set; }

        [DisplayName("Thể Loại")]
        [Required]
        public int TheLoaiID { get; set; }

        [DisplayName("Người dùng ID")]
        [Required]
        public int NguoiDungID { get; set; }

        public virtual TheLoaiModels TheLoaiModels { get; set; }
        public virtual ICollection<CommentModels> dsCmtBaiViet { get; set; }

        public BaiVietModels()
        {
            dsCmtBaiViet = new List<CommentModels>();
        }
    }
}