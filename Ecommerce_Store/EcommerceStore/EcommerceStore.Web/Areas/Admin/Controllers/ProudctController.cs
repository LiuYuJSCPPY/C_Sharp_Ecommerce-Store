using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var proudcts = db.Proudcts.Include(p => p.Category).Include(p => p.Discount);
            return View(await proudcts.ToListAsync());
        }

        // GET: Admin/Proudct/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proudct proudct = await db.Proudcts.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Decsription,Stock_Keep,CategoryId,price,DiscountId,ProudctImage,Create_at,Modified_at")] Proudct proudct,ProudctImage proudctImage,HttpPostedFileBase Proudcts)
        {
            if (ModelState.IsValid)
            {
                db.Proudcts.Add(proudct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", proudct.CategoryId);
            ViewBag.DiscountId = new SelectList(db.Discounts, "Id", "Name", proudct.DiscountId);
            return View(proudct);
        }

        // GET: Admin/Proudct/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proudct proudct = await db.Proudcts.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Decsription,Stock_Keep,CategoryId,price,DiscountId,ProudctImage,Create_at,Modified_at")] Proudct proudct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proudct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", proudct.CategoryId);
            ViewBag.DiscountId = new SelectList(db.Discounts, "Id", "Name", proudct.DiscountId);
            return View(proudct);
        }

        // GET: Admin/Proudct/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proudct proudct = await db.Proudcts.FindAsync(id);
            if (proudct == null)
            {
                return HttpNotFound();
            }
            return View(proudct);
        }

        // POST: Admin/Proudct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Proudct proudct = await db.Proudcts.FindAsync(id);
            db.Proudcts.Remove(proudct);
            await db.SaveChangesAsync();
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
