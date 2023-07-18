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
            ViewBag.DanhMuc = db.ProductCategories.ToList();
            ViewBag.DuongDa = db.Products.Where(x => x.ProductCategory.Alias.Equals("DD")).ToList();
            ViewBag.TrangDiem = db.Products.Where(x => x.ProductCategory.Alias.Equals("TD")).ToList();
            ViewBag.SonMoi = db.Products.Where(x => x.ProductCategory.Alias.Equals("SM")).ToList();
            ViewBag.DuongBody = db.Products.Where(x => x.ProductCategory.Alias.Equals("DB")).ToList();
            ViewBag.TrangSuc = db.Products.Where(x => x.ProductCategory.Alias.Equals("TSS")).ToList();
            return View();
        }

    }
}