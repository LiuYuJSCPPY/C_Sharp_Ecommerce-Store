using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceStore.Model;

namespace EcommerceStore.Web.Areas.Admin.ViewModel
{
    public class EcommerceStoreViewCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategroyImage { get; set; }
    }

    public class EcommerceStoreCategoryList
    {
        public IEnumerable<Category> categories { get; set; }
    }

    
}