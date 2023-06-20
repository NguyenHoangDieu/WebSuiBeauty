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
    public class ProductCategoriesAdminController : Controller
    {
        private WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();

        // GET: ProductCategoriesAdmin
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        // GET: ProductCategoriesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: ProductCategoriesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategoriesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                ProductCategory category = new ProductCategory
                {
                    Name = model.Name,
                    Alias = model.Alias,
                    ParentId = model.ParentId,
                    Description = model.Description,
                    Status = model.Status,
                };
                db.ProductCategories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ProductCategoriesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            CategoryVM category = new CategoryVM
            {
                Id = productCategory.Id, 
                Name = productCategory.Name, 
                Alias = productCategory.Alias,
                ParentId = productCategory.ParentId,
                Description = productCategory.Description,
                Status = productCategory.Status,
            };
            return View(category);
        }

        // POST: ProductCategoriesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                ProductCategory productCategory = new ProductCategory
                {
                    Id= model.Id,
                    Name = model.Name,
                    Alias = model.Alias,
                    ParentId = model.ParentId,
                    Description = model.Description,
                    Status = model.Status,

                };
                db.Entry(productCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ProductCategoriesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategoriesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            db.ProductCategories.Remove(productCategory);
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
