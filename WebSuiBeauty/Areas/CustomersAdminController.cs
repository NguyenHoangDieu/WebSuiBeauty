using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSuiBeauty.Data;
using WebSuiBeauty.Migrations;
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Areas
{
    public class CustomersAdminController : Controller
    {
        private WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();

        // GET: CustomersAdmin
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: CustomersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            CustomerVM model = new CustomerVM
            {
                Id = customer.Id,
                First_Name = customer.First_Name,
                Last_Name = customer.Last_Name,
                Email = customer.Email,
                DateofBirth = customer.DateOfBirth,
                Password = customer.Password,
                Phone = customer.Phone,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                Avatar = customer.Avatar,
                Status = true,
            };
          
            return View(model);
        }
        [HttpPost]
        public ActionResult Details(CustomerVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.AvatarUpload != null)
                {
                    string filePath = Path.Combine("Assets", Guid.NewGuid().ToString() + Path.GetExtension(model.AvatarUpload.FileName));
                    model.AvatarUpload.SaveAs(Server.MapPath(filePath));
                    Customer customer = new Customer
                    {
                        Id = model.Id,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        Email = model.Email,
                        DateOfBirth = model.DateofBirth,
                        Password = model.Password,
                        Phone = model.Phone,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        Avatar = filePath,
                        Status = true,
                    };
                    db.Entry(customer).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Customer customer = new Customer
                    {
                        Id = model.Id,
                        First_Name = model.First_Name,
                        DateOfBirth=model.DateofBirth,
                        Last_Name = model.Last_Name,
                        Email = model.Email,
                        Password = model.Password,
                        Phone = model.Phone,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        Status = true,
                    };
                    db.Entry(customer).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
        // GET: CustomersAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerVM model)
        {
            if (ModelState.IsValid)
            {
                string filePath = model.Avatar;
                if (model.AvatarUpload != null && model.AvatarUpload.ContentLength > 0)
                {
                    filePath = Path.Combine("~/Assets/Images", Guid.NewGuid().ToString() + Path.GetExtension(model.AvatarUpload.FileName));
                    model.AvatarUpload.SaveAs(Server.MapPath(filePath));
                    Customer customer = new Customer
                    {
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        Email = model.Email,
                        DateOfBirth = model.DateofBirth,
                        Password = model.Password,
                        Phone = model.Phone,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        Avatar = filePath,
                        Status = true,
                    };
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Customer customer = new Customer
                    {
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        Email = model.Email,
                        DateOfBirth = model.DateofBirth,
                        Password = model.Password,
                        Phone = model.Phone,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        Status = true,
                    };
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        // GET: CustomersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            CustomerVM model = new CustomerVM
            {
                Id = customer.Id,
                First_Name = customer.First_Name,
                Last_Name = customer.Last_Name,
                Email = customer.Email,
                DateofBirth = customer.DateOfBirth,
                Password = customer.Password,
                Phone = customer.Phone,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                Avatar = customer.Avatar,
                Status = true,

            };
            return View(model);
        }

        // POST: CustomersAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerVM model)
        {
            if (ModelState.IsValid)
            {
                string filePath = model.Avatar;
                if (model.AvatarUpload != null && model.AvatarUpload.ContentLength > 0)
                {
                    filePath = Path.Combine("~/Assets/Images", Guid.NewGuid().ToString() + Path.GetExtension(model.AvatarUpload.FileName));
                    model.AvatarUpload.SaveAs(Server.MapPath(filePath));
                    Customer customer = new Customer
                    {
                        Id = model.Id,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        Email = model.Email,
                        Password = model.Password,
                        DateOfBirth = model.DateofBirth,
                        Phone = model.Phone,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        Avatar = filePath,
                        Status = true,
                    };
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Customer customer = new Customer
                    {
                        Id = model.Id,
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        Email = model.Email,
                        Password = model.Password,
                        DateOfBirth = model.DateofBirth,
                        Phone = model.Phone,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        Avatar = filePath,
                        Status = true,

                    };
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        // GET: CustomersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: CustomersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
