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
using EcommerceStore.Web.Areas.Admin.ViewModel;
using EcommerceStore.Serivce;
using System.IO;

namespace EcommerceStore.Web.Areas.Admin.Controllers
{
    public class DiscountController : Controller
    {
        private EcommerceStoreContext db = new EcommerceStoreContext();
        private DiscountSerivce discountSerivce = new DiscountSerivce();

        // GET: Admin/Discount
        public async Task<ActionResult> Index()
        {
            EcommerceStoreDiscountList ecommerceStoreDiscountList =new EcommerceStoreDiscountList ();
            ecommerceStoreDiscountList.discounts =discountSerivce.GetAllEcommerceDiscounts();

            return View(ecommerceStoreDiscountList);
        }


        //public ActionResult Listing()
        //{
        //    return PartialView("_Listing");
        //}

        public ActionResult Action()
        {
            return PartialView("_Action");
        }

        [HttpPost]
        public JsonResult Action([Bind(Include = "Id,Name,Description,DescriptImage,DiscountPreceint,enabled,StartDiscount,EndDiscount,Create_at,Modified_at")] Discount discount,HttpPostedFileBase DiscountImage )
        {
            JsonResult json = new JsonResult();
            var Result = false;

            



            string FilePath = Server.MapPath("Areas/Admin/Image/Discount/");
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string FileName = Path.GetFileName(DiscountImage.FileName);
            string _FileName = DateTime.Now.ToString() + FileName;
            string exesption = Path.GetExtension(DiscountImage.FileName);
            string _FilePath = Path.Combine(FilePath, _FileName);

            
            discount.Create_at = DateTime.Now;
            discount.Modified_at = DateTime.Now;
            discount.DescriptImage = "Areas/Admin/Image/Discount/" + _FileName;

            if (exesption.ToLower() == ".png" || exesption.ToLower() == ".peng" || exesption.ToLower() == ".jpg")
            {
                if(DiscountImage.ContentLength < 10000000000)
                {
                    Result = discountSerivce.SaveEcommerceStoreDiscounts(discount);
                    if (Result)
                    {
                        DiscountImage.SaveAs(_FilePath);
                    }
                }
            }


            if (Result)
            {
                json.Data = new { Success = true };

            }
            else
            {
                json.Data = new { Success = false ,Message = "新增尚未成功!"};
            }


            return json;
        }

        // GET: Admin/Discount/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = await db.Discounts.FindAsync(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // GET: Admin/Discount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Discount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,DescriptImage,DiscountPreceint,Create_at,Modified_at")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                db.Discounts.Add(discount);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(discount);
        }

        // GET: Admin/Discount/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = await db.Discounts.FindAsync(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // POST: Admin/Discount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,DescriptImage,DiscountPreceint,Create_at,Modified_at")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(discount);
        }

        // GET: Admin/Discount/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = await db.Discounts.FindAsync(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // POST: Admin/Discount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Discount discount = await db.Discounts.FindAsync(id);
            db.Discounts.Remove(discount);
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
