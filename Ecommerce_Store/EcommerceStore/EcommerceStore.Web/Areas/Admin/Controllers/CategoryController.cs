using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceStore.Data;
using EcommerceStore.Model;
using EcommerceStore.Serivce;
using EcommerceStore.Web.Areas.Admin.ViewModel;

namespace EcommerceStore.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private CategorySerivce categorySerivce = new CategorySerivce();
        private EcommerceStoreContext db = new EcommerceStoreContext();

        // GET: Admin/Category
        public ActionResult Index()
        {
            EcommerceStoreCategoryList ecommerceStoreCategoryList = new EcommerceStoreCategoryList();
           ecommerceStoreCategoryList.categories = categorySerivce.GetAllEcommerceStoreCategories();
            return View(ecommerceStoreCategoryList);
        }

        //public ActionResult Listing()
        //{

        //    return View();
        //}

        public ActionResult Action()
        {
            return PartialView("_Action");
        }



        [HttpPost]
        public JsonResult Action([Bind(Include = "Id,Name,CategoryImage")] Category CategoryModel,HttpPostedFileBase CategoryImage,int? Id)
        {
            JsonResult json = new JsonResult();
            Category category = new Category();
            bool result = false;

            if (Id != null)
            {
                category = db.Categories.Find(Id);

                string FilePath = Server.MapPath("~/Areas/Admin/Image/CategoryImage/");

                string FileName = Path.GetFileName(CategoryImage.FileName);
                string _FileName = DateTime.Now.ToString("yyyymmssfff") + FileName;
                string Exesption = Path.GetExtension(CategoryImage.FileName);
                string path = Path.Combine(FilePath, _FileName);
                category.Name = CategoryModel.Name;
                category.CategoryImage = CategoryModel.CategoryImage;
                var OldCategoryImage = Request.MapPath(category.CategoryImage.ToString());
                if(Exesption.ToLower() == ".png" || Exesption.ToLower() == ".jepg" || Exesption.ToLower() == ".jpg")
                {
                    if(CategoryImage.ContentLength < 10000000)
                    {
                        result = categorySerivce.EditEcommerceStoreCategory(category);
                        if (result)
                        {
                            CategoryImage.SaveAs(path);
                            if (System.IO.File.Exists(OldCategoryImage))
                            {
                                System.IO.File.Delete(OldCategoryImage);
                            }
                        }
                    }
                }
            }
            else
            {
                string FilePath = Server.MapPath("~/Areas/Admin/Image/CategoryImage/");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string FileName = Path.GetFileName(CategoryImage.FileName);
                string _FileName = DateTime.Now.ToString("yyyymmssfff") + FileName;
                string exesption = Path.GetExtension(CategoryImage.FileName);
                string path = Path.Combine(FilePath, _FileName);
                category.Name = CategoryModel.Name;
                category.CategoryImage = "~/Areas/Admin/Image/CategoryImage/" + _FileName;
                if(exesption.ToLower() == ".jpg" || exesption.ToLower() == ".jepg" || exesption.ToLower() == ".png")
                {
                    if(CategoryImage.ContentLength < 10000000)
                    {
                        result = categorySerivce.SaveEcommerceStoreCategory(category);
                        if (result)
                        {
                            CategoryImage.SaveAs(path);
                        }
                    }
                }
            }

          

            

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false ,Message = "上傳時出現問題!"};
            }


            return json;
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryImage")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryImage")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
