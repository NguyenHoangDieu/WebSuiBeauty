using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Areas
{
    public class OrdersAdminController : Controller
    {
        private WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();

        // GET: OrdersAdmin
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: OrdersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: OrdersAdmin/Create
        public ActionResult Create()
        {
            var paymentMethods = new Dictionary<string, string>
            {
                { "ATM", PaymentMethod.DefaultPaymentMethods.ATM },
                { "Tiền mặt", PaymentMethod.DefaultPaymentMethods.Cash },
                { "Thanh toán tại cửa hàng", PaymentMethod.DefaultPaymentMethods.StorePayment }
            };

            ViewBag.PaymentMethods = new SelectList(paymentMethods, "Value", "Key");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Last_Name");
            return View();
        }

        // POST: OrdersAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM model)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                    PaymentMethod = model.PaymentMethod,
                    CustomerAddress = model.CustomerAddress,
                    CustomerEmail = model.CustomerEmail,
                    CustomerMessage = model.CustomerMessage,
                    CustomerMobile = model.CustomerMobile,
                    Status = true,
                    PaymentStatus = "Chờ xử lý",
                    CreatedDate = DateTime.Now,
            };
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: OrdersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            var paymentMethods = new Dictionary<string, string>
            {
                { "ATM", PaymentMethod.DefaultPaymentMethods.ATM },
                { "Tiền mặt", PaymentMethod.DefaultPaymentMethods.Cash },
                { "Thanh toán tại cửa hàng", PaymentMethod.DefaultPaymentMethods.StorePayment }
            };

            ViewBag.PaymentMethods = new SelectList(paymentMethods, "Value", "Key");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Last_Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            OrderVM model = new OrderVM
            {
                CustomerId = order.CustomerId,
                CustomerName = order.CustomerName,
                PaymentMethod = order.PaymentMethod,
                CustomerAddress = order.CustomerAddress,
                CustomerEmail = order.CustomerEmail,
                CustomerMessage = order.CustomerMessage,
                CustomerMobile = order.CustomerMobile,
                Status = true,
                PaymentStatus = "Chờ xử lý",
                CreatedDate = DateTime.Now,
            };
            return View(model);
        }

        // POST: OrdersAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderVM model)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                    PaymentMethod = model.PaymentMethod,
                    CustomerAddress = model.CustomerAddress,
                    CustomerEmail = model.CustomerEmail,
                    CustomerMessage = model.CustomerMessage,
                    CustomerMobile = model.CustomerMobile,
                    Status = true,
                    PaymentStatus = "Chờ xử lý",
                    CreatedDate = DateTime.Now,
                };
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: OrdersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: OrdersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
