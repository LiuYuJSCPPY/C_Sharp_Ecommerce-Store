using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceStore.Model;

namespace EcommerceStore.Web.Areas.Admin.ViewModel
{
    public class EcommerceStoreCategory
    {
    }

    public class EcommerceStoreCategoryList
    {
        public IEnumerable<Category> categories { get; set; }
    }

    
}