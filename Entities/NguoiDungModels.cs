using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTinTuc.Models
{
    public class NguoiDungModels
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Required]
        public string NguoiDungID { get; set; }

        [Required]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [Required]
        [DisplayName("Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [EmailAddress]
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("SĐT")]
        public string SDT { get; set; }

        [Required]
        [DisplayName("CMND")]
        public string CMND { get; set; }

        [Required]
        [DisplayName("Trạng Thái")]
        public bool TrangThai { get; set; }

        public virtual ICollection<BaiVietModels> dsBaiViet { get; set; }
        public NguoiDungModels()
        {
            dsBaiViet = new List<BaiVietModels>();           
        }
    }
}