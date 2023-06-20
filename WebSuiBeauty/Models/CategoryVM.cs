using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSuiBeauty.Data;
using WebSuiBeauty.Data.Abstract;

namespace WebSuiBeauty.Models
{
    public class CategoryVM : Auditable
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [Display(Name = "Tên danh mục")]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required(ErrorMessage = "Mã code danh mục không được để trống")]
        [Display(Name = "Mã code danh mục")]
        [MaxLength(256)]
        public string Alias { set; get; }

        [MaxLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { set; get; }
        [Display(Name = "Cấp cha")]
        public int? ParentId { set; get; }
        public virtual IEnumerable<Product> Products { set; get; }
    }
}