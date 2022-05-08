using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceStore.Data;
using EcommerceStore.Model;
using System.Web;
using System.Data.Entity;

namespace EcommerceStore.Serivce
{
    public class CategorySerivce
    {
        public IEnumerable<Category> GetAllEcommerceStoreCategories()
        {
            var context = new EcommerceStoreContext();
            return context.Categories.ToList();
        }



        public bool SaveEcommerceStoreCategory(Category category)
        {
            var context = new EcommerceStoreContext();

            context.Categories.Add(category);
            return context.SaveChanges() > 0;
        }

        public bool EditEcommerceStoreCategory(Category category)
        {
            EcommerceStoreContext context = new EcommerceStoreContext();
            context.Entry(category).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }
       
       
    }
}
