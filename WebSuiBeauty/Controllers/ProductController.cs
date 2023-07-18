using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Controllers
{
    public class ProductController : Controller
    {
        WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(int id)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.ProductId = id;
            int quantity = 1;
            decimal price = db.Products.Find(id).Price;
            orderDetail.Quantity = quantity;
            orderDetail.Price = price;
            orderDetail.Total = quantity * price;
            orderDetail.Product = db.Products.Find(id);

            if (TempDataVM.items == null)
            {
                TempDataVM.items = new List<OrderDetail>();
            }
            TempDataVM.items.Add(orderDetail);
            return RedirectToAction("Index", "MyCart"); ;

        }
        public ActionResult ViewDetails(int id)
        {
            var prod = db.Products.Find(id);
            ViewBag.RelatedProducts = db.Products.Where(y => y.CategoryId == prod.CategoryId).ToList();
            this.GetDefaultData();
            return View(prod);
        }
    }
}