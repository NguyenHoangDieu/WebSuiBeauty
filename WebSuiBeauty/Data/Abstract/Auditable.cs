using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Data.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTime? ModifiedDate { set; get; }

        [MaxLength(256)]
        public string ModifiedBy { set; get; }

        [MaxLength(256)]
        public string MetaKeywords { set; get; }

        [MaxLength(256)]
        public string MetaDescriptions { set; get; }

        public bool Status { set; get; }
    }
}