using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace WebSuiBeauty.Data
{
    [Table("ContentTag")]
    public class ContentTag
    {
        [Key]
        [Column(Order = 1)]
        public int ContentId { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagId { set; get; }

        [ForeignKey("ContentId")]
        public virtual Content Content { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}