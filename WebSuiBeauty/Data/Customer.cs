using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebSuiBeauty.Data.Abstract;

namespace WebSuiBeauty.Data
{
    public class Customer : Auditable
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Họ và tên đệm")]
        public string First_Name { get; set; }
        [Display(Name = "Tên")]
        public string Last_Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [
         Display(Name = "Ngày sinh"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
         DataType(DataType.Date)
     ]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Quốc tịch")]
        public string Country { get; set; }
        [Display(Name = "Thành phố")]
        public string City { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Avatar")]
        public string Avatar { get; set; }
    }
}