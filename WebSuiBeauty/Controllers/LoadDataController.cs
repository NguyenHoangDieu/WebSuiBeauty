using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Controllers
{
    public static class LoadDataController
    {
        static WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();
        // GET: LoadData
        public static List<OrderDetail> GetDefaultData(this ControllerBase controller)
        {
            if (TempDataVM.items == null)
            {
                TempDataVM.items = new List<OrderDetail>();
            }
            var data = TempDataVM.items.ToList();

            controller.ViewBag.cartBox = data.Count == 0 ? null : data;
            controller.ViewBag.NoOfItem = data.Count();
            int? SubTotal = Convert.ToInt32(data.Sum(x => x.Total));
            controller.ViewBag.Total = SubTotal;

            int Discount = 0;
            controller.ViewBag.SubTotal = SubTotal;
            controller.ViewBag.Discount = Discount;
            controller.ViewBag.TotalAmount = SubTotal - Discount;
            return data;
        }
    }
}