using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSuiBeauty.Data;
using WebSuiBeauty.Data.Abstract;
using System.ComponentModel;

namespace WebSuiBeauty.Models
{
    public class ProductVM : Auditable
    {
        
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm")]
        [MaxLength(256)]
        [DisplayName("Tên sản phẩm")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập danh mục sản phẩm")]
        [DisplayName("Danh mục sản phẩm")]
        public int CategoryId { set; get; }

        [MaxLength(256)]
        [DisplayName("Ảnh đại diện")]
        public string Image { set; get; }
        public HttpPostedFileBase ImageUpload { get; set; }
        [DisplayName("Giá sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public decimal Price { set; get; }
        [DisplayName("Giảm giá (%)")]
        public decimal? PromotionPrice { set; get; }
        [DisplayName("Bảo hành")]
        public int? Warranty { set; get; }
        [DisplayName("Mô tả")]
        [MaxLength(500)]
        [Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm")]
        public string Description { set; get; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng sản phẩm")]
        public int Quantity { set; get; }
        public bool IsCheck { set; get; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }
    }
}