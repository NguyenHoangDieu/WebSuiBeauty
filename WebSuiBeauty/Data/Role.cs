using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Data
{
    public partial class Role
    {
        public Role()
        {
            this.adminLogin = new HashSet<AdminLogin>();
        }
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AdminLogin> adminLogin { get; set; }
    }
}