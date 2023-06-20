using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSuiBeauty.Data.Abstract;

namespace WebSuiBeauty.Data
{
    [Table("Content")]
    public class Content : Auditable
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { set; get; }

        [Required]
        public int CategoryId { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public string Post { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        [ForeignKey("CategoryId")]
        public virtual ContentCategory ContentCategory { set; get; }

        public virtual IEnumerable<ContentTag> PostTags { set; get; }
    }
}