using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using WebSuiBeauty.Data.Abstract;

namespace WebSuiBeauty.Data
{
    [Table("Product")]

    public class Product : Auditable
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int CategoryId { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }

        public decimal Price { set; get; }

        public decimal? PromotionPrice { set; get; }

        public int? Warranty { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public int? ViewCount { set; get; }

        public int Quantity { set; get; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}