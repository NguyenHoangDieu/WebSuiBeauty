using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSuiBeauty.Data
{
    public class AdminLogin
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int EmpID { get; set; }
        public Nullable<int> RoleType { get; set; }
        public string Notes { get; set; }
        public virtual Role Role { get; set; }
        public virtual Employee Employee { get; set; }
    }
}