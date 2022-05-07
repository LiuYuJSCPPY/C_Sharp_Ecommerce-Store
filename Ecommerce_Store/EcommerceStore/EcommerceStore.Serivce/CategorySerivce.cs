using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceStore.Data;
using EcommerceStore.Model;

namespace EcommerceStore.Serivce
{
    public class CategorySerivce
    {
        public IEnumerable<Category> GetAllEcommerceStoreCategories()
        {
            var context = new EcommerceStoreContext();
            return context.Categories.ToList();
        }

       
    }
}
