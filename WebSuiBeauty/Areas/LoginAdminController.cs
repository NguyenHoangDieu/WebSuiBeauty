using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Areas
{
    public class LoginAdminController : Controller
    {

        WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();
        // GET: Login
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(AdminLoginVM login)
        {
            if (ModelState.IsValid)
            {
                var model = (from m in db.AdminLogins
                             where m.UserName == login.UserName && m.Password == login.Password
                             select m).Any();

                if (model)
                {
                    var loginInfo = db.AdminLogins.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();

                    Session["username"] = loginInfo.UserName;
                    TempDataVM.EmpID = loginInfo.EmpID;
                    return RedirectToAction("Index", "AdminDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                    return View();
                }
            }
            return View();
        }
        // Logout Server Code
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("LoginAdmin", "LoginAdmin");
        }
    }
}