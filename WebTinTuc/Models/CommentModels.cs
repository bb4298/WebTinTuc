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
    public class CommentModels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int CmtID { get; set; }

        [Required]
        [DisplayName("Nội Dung Commnet")]
        public string NoiDung { get; set; }

        [Required]
        [DisplayName("Ngày Comment")]
        public DateTime NgayCmt { get; set; }

        [Required]
        [DisplayName("Trạng Thái Duyệt")]
        public bool TrangThaiDuyet { get; set; }

        public int BaiVietID { get; set; }

        public int NguoiDungID { get; set; }


        public virtual BaiVietModels BaiVietModels { get; set; }     
        public virtual NguoiDungModels NguoiDungModels { get; set; }

    }
}