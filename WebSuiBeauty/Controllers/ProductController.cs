using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;
using PagedList;

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
            decimal price = db.Products.Find(id).PriceAfterPromotion??0;
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
            var reviews = db.Reviews.Where(x => x.ProductId == id).ToList();
            ViewBag.Reviews = reviews;
            ViewBag.TotalReviews = reviews.Count();
            ViewBag.RelatedProducts = db.Products.Where(y => y.CategoryId == prod.CategoryId).ToList();
            var ratedProd = db.Reviews.Where(x => x.ProductId == id).ToList();
            int TotalRate = ratedProd.Sum(x => x.Rate).GetValueOrDefault();
            int count = ratedProd.Count();
            ViewBag.AvgRate = TotalRate > 0 ? TotalRate / count : 0;
            this.GetDefaultData();
            return View(prod);
        }

        public ActionResult AddReview(int productID, FormCollection getReview)
        {

            Review review = new Review();
            review.CustomerId = TempDataVM.UserId;
            review.ProductId = productID;
            review.Name = getReview["name"];
            review.Email = getReview["email"];
            review.Review1 = getReview["message"];
            review.Rate = Convert.ToInt32(getReview["rate"]);
            review.DateTime = DateTime.Now;

            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("ViewDetails/" + productID + "");

        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Search(string product, int? page)
        {

            List<Product> products;
            if (!string.IsNullOrEmpty(product))
            {
                products = db.Products.Where(x => x.Name.Contains(product)).ToList();
            }
            else
            {
                products = db.Products.ToList();
            }
            return View("Products", products.ToPagedList(page ?? 1, 6));
        }

             public JsonResult GetProducts(string term)
        {
            List<string> prodNames = db.Products.Where(x => x.Name.Contains(term)).Select(y => y.Name).ToList();
            return Json(prodNames, JsonRequestBehavior.AllowGet);
        }


    }
}