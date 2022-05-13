using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceStore.Model;


namespace EcommerceStore.Web.Areas.Admin.ViewModel
{
    public class EcommerceStoreDiscount
    {
    }
    public class EcommerceStoreDiscountList
    {
       public IEnumerable<Discount> discounts { get; set; }
    }
   
}