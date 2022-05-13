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

        public ActionResult Action(int? Id)
        {
            var model = new EcommerceStoreViewCategory();

            if(Id.HasValue)
            {
                var categroy = categorySerivce.GetCategroyId(Id.Value);
                model.Id = categroy.Id;
                model.Name = categroy.Name;
                model.CategroyImage = categroy.CategoryImage;
            }

            return PartialView("_Action", model);
        }



        [HttpPost]
        public JsonResult Action([Bind(Include = "Id,Name,CategoryImage")] Category CategoryModel,HttpPostedFileBase CategoryImage)
        {
            JsonResult json = new JsonResult();
            
            bool result = false;

            if (CategoryModel.Id > 0)
            {
                var OldCategoryImage = Request.MapPath(db.Categories.Find(CategoryModel.Id).CategoryImage.ToString()); 
                
                Category category = new Category();

                string FilePath = Server.MapPath("~/Areas/Admin/Image/CategoryImage/");

                string FileName = Path.GetFileName(CategoryImage.FileName);
                string _FileName = DateTime.Now.ToString("yyyymmssfff") + FileName;
                string Exesption = Path.GetExtension(CategoryImage.FileName);
                string path = Path.Combine(FilePath, _FileName);

                category.Id = CategoryModel.Id;
                category.Name = CategoryModel.Name;
                category.CategoryImage = "~/Areas/Admin/Image/CategoryImage/" + _FileName;

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
                Category category = new Category();
                if(CategoryImage != null)
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
                else
                {
                    category.Name = CategoryModel.Name;
                    result = categorySerivce.SaveEcommerceStoreCategory(category);
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

     
        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
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
            return PartialView("_Delete", category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        
        public JsonResult Delete(Category category)
        {

            JsonResult json = new JsonResult ();
            bool Result = false;
            var DeleteCategroy = categorySerivce.GetCategroyId(category.Id);
            Result = categorySerivce.DeleteEcommerceStoreCategroy(DeleteCategroy);

            if (Result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "刪除失敗!" };
            }
            return json;
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
