using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Areas
{
    public class ProfileController : Controller
    {
        WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            return View(db.Employees.Find(TempDataVM.EmpID));
        }
    }
}