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
using WebSuiBeauty.Models;

namespace WebSuiBeauty.Areas
{
    public class ProductAdminController : Controller
    {
        private WebSuiBeautyDbContext db = new WebSuiBeautyDbContext();

        // GET: ProductAdmin
        public ActionResult Index()
        {
            
            var products = db.Products.Include(p => p.ProductCategory);
            return View(products.ToList());
        }

        // GET: ProductAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductVM model = new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                PromotionPrice = product.PromotionPrice,
                CategoryId = product.CategoryId,
                Warranty = product.Warranty,
                Quantity = product.Quantity,
                Description = product.Description,
                Status = product.Status,
                Image = product.Image,
                CreatedDate = product.CreatedDate,

            };
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.CategoryId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Details(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null)
                {
                    string filePath = Path.Combine("Assets", Guid.NewGuid().ToString() + Path.GetExtension(model.ImageUpload.FileName));
                    model.ImageUpload.SaveAs(Server.MapPath(filePath));
                    Product product = new Product
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Price = model.Price,
                        PromotionPrice = model.PromotionPrice,
                        CategoryId = model.CategoryId,
                        Image = filePath,
                        Warranty = model.Warranty,
                        Quantity = model.Quantity,
                        Description = model.Description,
                        Status = model.Status,
                        CreatedDate=model.CreatedDate,
                    };
                    db.Entry(product).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Product product = new Product
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Price = model.Price,
                        PromotionPrice = model.PromotionPrice,
                        CategoryId = model.CategoryId,
                        Warranty = model.Warranty,
                        Quantity = model.Quantity,
                        Description = model.Description,
                        Status = model.Status,
                        CreatedDate = model.CreatedDate,
                    };
                    db.Entry(product).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", model.CategoryId);
            return View(model);
        }
        // GET: ProductAdmin/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name");
            return View();
        }

        // POST: ProductAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                string filePath = model.Image;
                if (model.ImageUpload != null && model.ImageUpload.ContentLength>0)
                {
                    filePath = Path.Combine("~/Assets/Images", Guid.NewGuid().ToString() + Path.GetExtension(model.ImageUpload.FileName));
                    model.ImageUpload.SaveAs(Server.MapPath(filePath));
                    Product product = new Product
                    {
                        Name = model.Name,
                        Price = model.Price,
                        PromotionPrice = model.PromotionPrice,
                        CategoryId = model.CategoryId,
                        Image = filePath,
                        Warranty = model.Warranty,
                        Quantity = model.Quantity,
                        Description = model.Description,
                        Status = model.Status,
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Product product = new Product
                    {
                        Name = model.Name,
                        Price = model.Price,
                        PromotionPrice = model.PromotionPrice,
                        CategoryId = model.CategoryId,
                        Warranty = model.Warranty,
                        Quantity = model.Quantity,
                        Description = model.Description,
                        Status = model.Status,
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                   
            }

            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", model.CategoryId);
            return View(model);
        }

        // GET: ProductAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductVM model = new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                PromotionPrice = product.PromotionPrice,
                CategoryId = product.CategoryId,
                Warranty = product.Warranty,
                Quantity = product.Quantity,
                Description = product.Description,
                Status = product.Status,
                Image = product.Image,

            };
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.CategoryId);
            return View(model);
        }

        // POST: ProductAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVM model)
        {
            if (ModelState.IsValid)
            {
              
                string filePath = model.Image;
                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    filePath = Path.Combine("~/Assets/Images", Guid.NewGuid().ToString() + Path.GetExtension(model.ImageUpload.FileName));
                    model.ImageUpload.SaveAs(Server.MapPath(filePath));
                    Product product = new Product
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Price = model.Price,
                        PromotionPrice = model.PromotionPrice,
                        CategoryId = model.CategoryId,
                        Image = filePath,
                        Warranty = model.Warranty,
                        Quantity = model.Quantity,
                        Description = model.Description,
                        Status = model.Status,
                    };
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Product product = new Product
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Price = model.Price,
                        PromotionPrice = model.PromotionPrice,
                        CategoryId = model.CategoryId,
                        Warranty = model.Warranty,
                        Quantity = model.Quantity,
                        Description = model.Description,
                        Image = filePath,
                        Status = model.Status,
                    };
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
              
            }
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", model.CategoryId);
            return View(model);
        }

        // GET: ProductAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
