using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSuiBeauty.Data;

namespace WebSuiBeauty.Models
{
    public class TempDataVM
    {
        public static int EmpID { get; set; }
        public static int UserId { get; set; }
        public static List<OrderDetail> items { get; set; }
    }
}