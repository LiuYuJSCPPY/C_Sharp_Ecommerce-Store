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
    public class DiscountsController : Controller
    {
        private EcommerceStoreContext db = new EcommerceStoreContext();
        private DiscountSerivce discountSerivce = new DiscountSerivce();

        // GET: Admin/Discount
        public ActionResult Index()
        {
            EcommerceStoreDiscountList ecommerceStoreDiscountList = new EcommerceStoreDiscountList();
            ecommerceStoreDiscountList.discounts = discountSerivce.GetAllEcommerceDiscounts();

            return View(ecommerceStoreDiscountList);
        }


        //public ActionResult Listing()
        //{
        //    return PartialView("_Listing");
        //}

        public ActionResult Action(int? Id)
        {
            EcommerceStoreDiscount ecommerceStoreDiscount = new EcommerceStoreDiscount();
            if (Id.HasValue)
            {
               
                var Discount = discountSerivce.GetEcommerceStoreDiscountID(Id.Value);
                ecommerceStoreDiscount.Id = Id.Value;
                ecommerceStoreDiscount.Name = Discount.Name;
                ecommerceStoreDiscount.StartDiscount = (DateTime)Discount.StartDiscount;
                ecommerceStoreDiscount.DescriptImage = Discount.DescriptImage;
                ecommerceStoreDiscount.Description = Discount.Description;
                ecommerceStoreDiscount.DiscountPreceint = Discount.DiscountPreceint;
                ecommerceStoreDiscount.enabled = Discount.enabled;
                ecommerceStoreDiscount.EndDiscount = (DateTime)Discount.EndDiscount;

            }
            return PartialView("_Action", ecommerceStoreDiscount);
        }

        [HttpPost]
        public JsonResult Action([Bind(Include = "Id,Name,Description,DescriptImage,DiscountPreceint,enabled,StartDiscount,EndDiscount,Create_at")] Discount discount, HttpPostedFileBase DiscountImage)
        {
            JsonResult json = new JsonResult();
            var Result = false;


            //更新折扣
            if (discount.Id > 0)
            {
                Discount teamdiscount = discountSerivce.GetEcommerceStoreDiscountID(discount.Id);
                string OldDiscountImage = Request.MapPath(db.Discounts.Find(discount.Id).DescriptImage.ToString());
                string FilePath = Server.MapPath("~/Areas/Admin/Image/Discount/");
                string FileName = Path.GetFileName(DiscountImage.FileName);
                string _FileName = DateTime.Now.ToString("yyyymmssfff") + FileName;
                string exesption = Path.GetExtension(DiscountImage.FileName);
                string path = Path.Combine(FilePath, _FileName);

                Discount Editdiscount = new Discount
                {
                    Id = discount.Id,
                    Name = discount.Name,
                    Description = discount.Description,
                    DescriptImage = "~/Areas/Admin/Image/Discount/" + _FileName,
                    DiscountPreceint = discount.DiscountPreceint,
                    enabled = discount.enabled,
                    StartDiscount = discount.StartDiscount,
                    EndDiscount = discount.EndDiscount,
                    Create_at = teamdiscount.Create_at,
                    Modified_at = DateTime.Now,

                };


                if (exesption.ToLower() == ".png" || exesption.ToLower() == ".peng" || exesption.ToLower() == ".jpg")
                {
                    if (DiscountImage.ContentLength < 10000000000)
                    {
                        Result = discountSerivce.EditEcommerceStoreDiscounts(Editdiscount);
                        if (Result)
                        {
                            DiscountImage.SaveAs(path);
                            if (System.IO.File.Exists(OldDiscountImage))
                            {
                                System.IO.File.Delete(OldDiscountImage);
                            }
                        }
                    }
                }
            }
            else
            {

                //新增折扣
                string FilePath = Server.MapPath("~/Areas/Admin/Image/Discount/");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string FileName = Path.GetFileName(DiscountImage.FileName);
                string _FileName = DateTime.Now.ToString("yyyymmssfff") + FileName;
                string exesption = Path.GetExtension(DiscountImage.FileName);
                string path = Path.Combine(FilePath, _FileName);


                discount.Create_at = DateTime.Now;
                discount.Modified_at = DateTime.Now;
                discount.DescriptImage = "~/Areas/Admin/Image/Discount/" + _FileName;


                if (exesption.ToLower() == ".png" || exesption.ToLower() == ".peng" || exesption.ToLower() == ".jpg")
                {
                    if (DiscountImage.ContentLength < 10000000000)
                    {
                        Result = discountSerivce.SaveEcommerceStoreDiscounts(discount);
                        if (Result)
                        {
                            DiscountImage.SaveAs(path);
                        }
                    }
                }

            }


            if (Result)
            {
                json.Data = new { Success = true };

            }
            else
            {
                json.Data = new { Success = false, Message = "新增尚未成功!" };
            }


            return json;
        }



        // GET: Admin/Discount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = db.Discounts.Find(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", discount);
        }

        // POST: Admin/Discount/Delete/5
        [HttpPost]
        public JsonResult Delete(Discount discount)
        {
            JsonResult json = new JsonResult();
            bool Result = false;
            var DeleteDiscount = discountSerivce.GetEcommerceStoreDiscountID(discount.Id);

            Result = discountSerivce.DeleteEcommerceStoreDiscounts(DeleteDiscount);

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
