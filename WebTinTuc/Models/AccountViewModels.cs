using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTinTuc.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Họ tên tối đa {0} kí tự và tối thiểu {2} kí tự.", MinimumLength = 6)]
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [Required]       
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Địa chỉ tối đa {0} kí tự và tối thiểu {2} kí tự.", MinimumLength = 6)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "SĐT tối đa {0} kí tự và tối thiểu {2} kí tự.", MinimumLength = 6)]
        [Display(Name = "SDT")]
        public string SDT { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "CMND tối đa {0} kí tự và tối thiểu {2} kí tự.", MinimumLength = 6)]
        [Display(Name = "CMND")]
        public string CMND { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Mật khẩu tối đa {0} kí tự và tối thiểu {2} kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp !")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
