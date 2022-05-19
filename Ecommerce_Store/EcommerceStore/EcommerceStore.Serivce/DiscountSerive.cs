using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceStore.Model;
using EcommerceStore.Data;
using System.Data.Entity;

namespace EcommerceStore.Serivce
{
   public class DiscountSerivce
    {
        public IEnumerable<Discount> GetAllEcommerceDiscounts()
        {
            var Conetxt = new EcommerceStoreContext();
            return Conetxt.Discounts.ToList();
        }
        public IEnumerable<Category> GetAllEcommerceStoreCategories()
        {
            var context = new EcommerceStoreContext();
            return context.Categories.ToList();
        }

        public Discount GetEcommerceStoreDiscountID(int Id)
        {
            EcommerceStoreContext context = new EcommerceStoreContext();
            return context.Discounts.Find(Id);
        }



        public bool SaveEcommerceStoreDiscounts(Discount discount )
        {

            EcommerceStoreContext Context = new EcommerceStoreContext();
            
            Context.Discounts.Add(discount);

            return Context.SaveChanges() > 0;
        }

        public bool EditEcommerceStoreDiscounts(Discount discount)
        {
            EcommerceStoreContext Context = new EcommerceStoreContext();
            Context.Entry(discount).State = EntityState.Modified;

            return Context.SaveChanges() > 0;
        }

        public bool DeleteEcommerceStoreDiscounts(Discount discount)
        {
            var context = new EcommerceStoreContext();
          
            string OldDiscountImage = discount.DescriptImage;
            if (System.IO.File.Exists(discount.DescriptImage))
            {
                System.IO.File.Delete(discount.DescriptImage);
            }

            context.Entry(discount).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
    }
}
