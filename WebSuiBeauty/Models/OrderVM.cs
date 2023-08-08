using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Models
{
    public class OrderVM
    {
        public int Id { set; get; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public string CustomerName { set; get; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public string CustomerAddress { set; get; }
        [Display(Name = "Mã khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public int CustomerId { set; get; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public string CustomerEmail { set; get; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public string CustomerMobile { set; get; }
        [Display(Name = "Ghi chú khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        public string CustomerMessage { set; get; }
        [Display(Name = "Phương thức thanh toán")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]

        public string PaymentMethod { set; get; }

        public DateTime? CreatedDate { set; get; }
        [Display(Name = "Trạng thái thanh toán")]
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }
    }
}