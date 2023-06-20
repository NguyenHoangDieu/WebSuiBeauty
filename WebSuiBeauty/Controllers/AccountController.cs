using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Controllers
{
    public class AccountController : Controller
    {
        WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();

        public ActionResult Index()
        {
            //this.GetDefaultData();

            var usr = db.Customers.Find(TempDataVM.UserId);
            return View(usr);

        }

        [HttpPost]
        public ActionResult Update(Customer cust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Session["username"] = cust.Email;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formColl)
        {
            string usrName = formColl["Email"];
            string Pass = formColl["Password"];

            if (ModelState.IsValid)
            {
                var cust = (from ct in db.Customers
                            where (ct.Email == usrName && ct.Password == Pass)
                            select ct).SingleOrDefault();

                if (cust != null)
                {
                    TempDataVM.UserId = cust.Id;
                    Session["username"] = cust.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                    return View();
                }

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CustomerVM model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    Id = model.Id,
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    Password = model.Password,
                    DateOfBirth = model.DateofBirth,
                    Country = model.Country,
                    City = model.City,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    Status = true,
                };

                db.Customers.Add(customer);
                db.SaveChanges();
                return Redirect("/Account/Login");
            }
            return PartialView("_Error");
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            TempDataVM.UserId = 0;
            TempDataVM.items = null;
            return RedirectToAction("Index", "Home");
        }
    }
}