﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Data
{
    [Table("Order")]
    public class Order
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        [MaxLength(256)]
        public string CustomerName { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        [MaxLength(256)]
        public string CustomerAddress { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        [MaxLength(256)]
        public string CustomerEmail { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin này")]
        [MaxLength(256)]
        public string CustomerMessage { set; get; }

        [MaxLength(256)]
        public string PaymentMethod { set; get; }

        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        public int CustomerId { set; get; }

        //[ForeignKey("CustomerId")]
        //public virtual ApplicationUser User { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
    }
}