using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Assignment_4_TestFileForMVC_2.Models;

namespace Assignment_4_TestFileForMVC_2.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDBContext db = new ProductDBContext();

        // GET: Products
        public ActionResult Index(string searchBy, string search, int? Catagories, int? page)
        {
            ProductDBContext dbCatagory = new ProductDBContext();
            ViewBag.Catagories = new SelectList(dbCatagory.Categories, "CategoryId", "CategoryName");


            if (searchBy == "Name")
            {
                //if (Catagories != null)
                //{
                    var products = db.Products.Include(p => p.Category);

                    return View(products.Where(x => x.ProductName.StartsWith(search) && (x.PrimaryCategoryId == Catagories || Catagories == null))
                        .ToList().ToPagedList(page ?? 1, 50));
                //}
                //else { 
                //    var products = db.Products.Include(p => p.Category);
                //    return View(products.Where(x => x.ProductName.StartsWith(search) || search == null)
                //        .ToList().ToPagedList(page ?? 1,10));
                //}
            }
            else
            {
                var products = db.Products.Include(p => p.Category);
                return View(products.Where(x => x.ProductDescription.StartsWith(search) && x.PrimaryCategoryId == Catagories || Catagories == null)
                    .ToList().ToPagedList(page ?? 1,50));
            }

        }
        

        // GET: Products/Details/5
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
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.PrimaryCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductDescription,ProductPrice,Active,otherAttributes,PrimaryCategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrimaryCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.PrimaryCategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
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
            ViewBag.PrimaryCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.PrimaryCategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductDescription,ProductPrice,Active,otherAttributes,PrimaryCategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrimaryCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.PrimaryCategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
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

        // POST: Products/Delete/5
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
