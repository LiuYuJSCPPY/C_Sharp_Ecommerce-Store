using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceStore.Data;
using EcommerceStore.Model;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace EcommerceStore.Serivce
{
    public class CategorySerivce
    {
        public IEnumerable<Category> GetAllEcommerceStoreCategories()
        {
            var context = new EcommerceStoreContext();
            return context.Categories.ToList();
        }



        public Category GetCategroyId (int Id)
        {
            var context = new EcommerceStoreContext();
            return context.Categories.Find(Id);
        }

        public bool SaveEcommerceStoreCategory(Category category)
        {
            var context = new EcommerceStoreContext();

            context.Categories.Add(category);
            return context.SaveChanges() > 0;
        }

        public bool EditEcommerceStoreCategory(Category category)
        {
           var Context = new EcommerceStoreContext();
            Context.Entry(category).State =EntityState.Modified;
            return Context.SaveChanges() > 0;
        }

        public bool DeleteEcommerceStoreCategroy(Category category)
        {
            var context = new EcommerceStoreContext();
          
            if (File.Exists(category.CategoryImage))
            {
                File.Delete(category.CategoryImage);
                
            }
            
            context.Entry(category).State = EntityState.Deleted;
            return context.SaveChanges()>0;
        }
       
       
    }
}
