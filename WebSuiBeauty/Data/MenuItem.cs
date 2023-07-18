using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Data
{
    [Table("MenuItem")]
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int? ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }

}