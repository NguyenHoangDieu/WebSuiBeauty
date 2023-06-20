using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSuiBeauty.Data.Abstract;

namespace WebSuiBeauty.Data
{
    [Table("ContentCategory")]
    public class ContentCategory : Auditable
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string Alias { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public int? ParentId { set; get; }
        public int? DisplayOrder { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<Content> Content { set; get; }
    }
}