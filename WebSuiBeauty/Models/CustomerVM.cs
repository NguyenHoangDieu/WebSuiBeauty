using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebSuiBeauty.Models
{
    public class CustomerVM
    {
        public int Id { get; set; }
        [Display(Name = "Họ và tên đệm")]
        [Required(ErrorMessage = "Họ và tên đệm không được để trống")]
        public string First_Name { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage ="Email không được để trống")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Hãy nhập đúng địa chỉ email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Password không được để trống")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [
            Display(Name = "Ngày sinh"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            DataType(DataType.Date)
        ]
        public DateTime DateofBirth { get; set; }

        [Display(Name = "Quốc tịch")]
        [Required(ErrorMessage = "Quốc tịch không được để trống")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Thành phố không được để trống")]
        [Display(Name = "Thành phố")]
        public string City { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại chỉ bao gồm số 0-9")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
        [Display(Name = "Avatar")]
        public string Avatar { get; set; }
        public HttpPostedFileBase AvatarUpload { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }
    }
}