using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Controllers
{
    public class OrderController : Controller
    {
        WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();
        // GET: Order
        public ActionResult Index()
        {

            var paymentMethods = new Dictionary<string, string>
            {
                { "ATM", PaymentMethod.DefaultPaymentMethods.ATM },
                { "Tiền mặt", PaymentMethod.DefaultPaymentMethods.Cash },
                { "Thanh toán tại cửa hàng", PaymentMethod.DefaultPaymentMethods.StorePayment }
            };

            ViewBag.PaymentMethods = new SelectList(paymentMethods, "Value", "Key");
            return View();
        }
        public ActionResult ListOrder()
        {
            var idUser = TempDataVM.UserId;
            if(idUser!= 0) 
            {
                ViewBag.ListOrder = db.Orders.Where(x => x.CustomerId == idUser).ToList();
            }
            
            return View();
        }
        public ActionResult PlaceOrder(OrderVM model)
        {
            //int orderID = 1;
            //if (db.Orders.Count() > 0)
            //{
            //    orderID = db.Orders.Max(x => x.Id) + 1;
            //}
         
            if(TempDataVM.items.Count > 0)
            {
                Order order = new Order();
                order.CustomerId = TempDataVM.UserId;
                order.CustomerName = model.CustomerName;
                order.PaymentMethod = model.PaymentMethod;
                order.CustomerAddress = model.CustomerAddress;
                order.CustomerEmail = model.CustomerEmail;
                order.CustomerMessage = model.CustomerMessage;
                order.CustomerMobile = model.CustomerMobile;
                order.Status = true;
                order.PaymentStatus = "Chờ xử lý";
                order.CreatedDate = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
                foreach (var product in TempDataVM.items)
                {
                    product.OrderId = order.Id;
                    product.Order = db.Orders.Find(order.Id);
                    product.Product = db.Products.Find(product.ProductId);
                    db.OrderDetails.Add(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "ThankYou");
            }
            else {
                return View(); 
            }
            
            

        }
    }
}