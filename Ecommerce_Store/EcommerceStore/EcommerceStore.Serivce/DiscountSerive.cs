using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceStore.Model;
using EcommerceStore.Data;

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



        public bool SaveEcommerceStoreDiscounts(Discount discount )
        {

            EcommerceStoreContext Context = new EcommerceStoreContext();
            
            Context.Discounts.Add(discount);

            return Context.SaveChanges() > 0;
        }

    }
}
