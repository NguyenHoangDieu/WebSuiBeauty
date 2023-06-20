using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebSuiBeauty.Data
{
    public partial class Employee
    {
        public Employee()
        {
            this.adminLogin = new HashSet<AdminLogin>();
        }
        [Key]
        public int EmpID { get; set; }
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [
            Display(Name = "Ngày sinh"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)
        ]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<AdminLogin> adminLogin { get; set; }
    }
}