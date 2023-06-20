using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;

namespace WebSuiBeauty.Controllers
{
    public class HomeController : Controller
    {
        WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.SanPham = db.Products.ToList();
            return View();
        }
    }
}