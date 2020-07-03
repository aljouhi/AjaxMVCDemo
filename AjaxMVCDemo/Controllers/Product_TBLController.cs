using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AjaxMVCDemo.Models;

namespace AjaxMVCDemo.Controllers
{
    public class Product_TBLController : Controller
    {
        private MyMVC_DBEntities db = new MyMVC_DBEntities();

        // GET: Product_TBL
        public ActionResult Index()
        {
            var product = db.Product_TBL.Include(p => p.Product_name).Include(p => p.Product_category).Include(p => p.Price);
            return View(db.Product_TBL.ToList());
        }
         [HttpPost]
        public PartialViewResult Index( string pname)
        {
           var product = db.Product_TBL.Where(o => o.Product_name.StartsWith("pname"));
            return PartialView(db.Product_TBL.ToList());
        }

        // GET: Product_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_TBL product_TBL = db.Product_TBL.Find(id);
            if (product_TBL == null)
            {
                return HttpNotFound();
            }
            return View(product_TBL);
        }

        // GET: Product_TBL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product_TBL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_id,Product_name,Product_category,Price,QTE")] Product_TBL product_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Product_TBL.Add(product_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_TBL);
        }

        // GET: Product_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_TBL product_TBL = db.Product_TBL.Find(id);
            if (product_TBL == null)
            {
                return HttpNotFound();
            }
            return View(product_TBL);
        }

        // POST: Product_TBL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_id,Product_name,Product_category,Price,QTE")] Product_TBL product_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_TBL);
        }

        // GET: Product_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_TBL product_TBL = db.Product_TBL.Find(id);
            if (product_TBL == null)
            {
                return HttpNotFound();
            }
            return View(product_TBL);
        }

        // POST: Product_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_TBL product_TBL = db.Product_TBL.Find(id);
            db.Product_TBL.Remove(product_TBL);
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
