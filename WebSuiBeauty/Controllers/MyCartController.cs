using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Controllers
{
    public class MyCartController : Controller
    {
        WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();
        // GET: MyCart
        public ActionResult Index()
        {
            var data = this.GetDefaultData();

            return View(data);

        }

        public ActionResult Remove(int id)
        {
            TempDataVM.items.RemoveAll(x => x.ProductId == id);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult ProcedToCheckout(FormCollection formcoll)
        {
            var a = TempDataVM.items.ToList();
            for (int i = 0; i < formcoll.Count / 2; i++)
            {

                int productId = Convert.ToInt32(formcoll["shcartID-" + i + ""]);
                var orderDetails = TempDataVM.items.FirstOrDefault(x => x.ProductId == productId);


                int qty = Convert.ToInt32(formcoll["Qty-" + i + ""]);
                orderDetails.Quantity = qty;
                orderDetails.Price = orderDetails.Price;
                orderDetails.Total = qty * orderDetails.Price;
                TempDataVM.items.RemoveAll(x => x.ProductId == productId);

                if (TempDataVM.items == null)
                {
                    TempDataVM.items = new List<OrderDetail>();
                }
                TempDataVM.items.Add(orderDetails);

            }

            return RedirectToAction("Index", "CheckOut");
        }
    }
}