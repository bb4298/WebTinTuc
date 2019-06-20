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
    public class TheLoaiModels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        [Required]        
        public int TheLoaiID  { get; set; }

        [Required]
        [DisplayName("Tên Thể Loại")]
        public string TenTheLoai { get; set; }

        [Required]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }

        public virtual ICollection<BaiVietModels> dsBaiViet { get; set; }

        public TheLoaiModels()
        {
            dsBaiViet = new List<BaiVietModels>();
        }
    }
}