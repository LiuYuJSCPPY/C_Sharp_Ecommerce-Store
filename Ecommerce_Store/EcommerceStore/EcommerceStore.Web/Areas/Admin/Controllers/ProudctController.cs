using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceStore.Data;
using EcommerceStore.Model;

namespace EcommerceStore.Web.Areas.Admin.Controllers
{
    public class ProudctController : Controller
    {
        private EcommerceStoreContext db = new EcommerceStoreContext();

        // GET: Admin/Proudct
        public ActionResult Index()
        {
            var proudcts = db.Proudcts.Include(p => p.Category).Include(p => p.Discount);
            return View(proudcts.ToList());
        }

        // GET: Admin/Proudct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proudct proudct = db.Proudcts.Find(id);
            if (proudct == null)
            {
                return HttpNotFound();
            }
            return View(proudct);
        }

        // GET: Admin/Proudct/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.DiscountId = new SelectList(db.Discounts, "Id", "Name");
            return View();
        }

        // POST: Admin/Proudct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Decsription,Stock_Keep,CategoryId,price,DiscountId,ProudctImage,Create_at,Modified_at")] Proudct proudct)
        {
            if (ModelState.IsValid)
            {
                db.Proudcts.Add(proudct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", proudct.CategoryId);
            ViewBag.DiscountId = new SelectList(db.Discounts, "Id", "Name", proudct.DiscountId);
            return View(proudct);
        }

        // GET: Admin/Proudct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proudct proudct = db.Proudcts.Find(id);
            if (proudct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", proudct.CategoryId);
            ViewBag.DiscountId = new SelectList(db.Discounts, "Id", "Name", proudct.DiscountId);
            return View(proudct);
        }

        // POST: Admin/Proudct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Decsription,Stock_Keep,CategoryId,price,DiscountId,ProudctImage,Create_at,Modified_at")] Proudct proudct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proudct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", proudct.CategoryId);
            ViewBag.DiscountId = new SelectList(db.Discounts, "Id", "Name", proudct.DiscountId);
            return View(proudct);
        }

        // GET: Admin/Proudct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proudct proudct = db.Proudcts.Find(id);
            if (proudct == null)
            {
                return HttpNotFound();
            }
            return View(proudct);
        }

        // POST: Admin/Proudct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proudct proudct = db.Proudcts.Find(id);
            db.Proudcts.Remove(proudct);
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
