using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSuiBeauty.Data.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        string CreatedBy { set; get; }
        DateTime? ModifiedDate { set; get; }
        string ModifiedBy { set; get; }

        string MetaKeywords { set; get; }
        string MetaDescriptions { set; get; }

        bool Status { set; get; }
    }
}
