using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Data
{
    public partial class Review
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Review1 { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<bool> isDelete { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}