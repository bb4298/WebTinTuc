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
    public class NguoiDungModels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int NguoiDungID { get; set; }

        
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        
        [DisplayName("Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [EmailAddress]
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        
        [DisplayName("SĐT")]
        public string SDT { get; set; }

        
        [DisplayName("CMND")]
        public string CMND { get; set; }

        
        [DisplayName("Trạng Thái")]
        public bool TrangThai { get; set; }

        public virtual ICollection<CommentModels> dsCmt { get; set; }
        public NguoiDungModels()
        {
            dsCmt = new List<CommentModels>();           
        }
    }
}