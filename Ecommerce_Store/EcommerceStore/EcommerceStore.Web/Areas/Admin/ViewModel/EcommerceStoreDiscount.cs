using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceStore.Model;


namespace EcommerceStore.Web.Areas.Admin.ViewModel
{
    public class EcommerceStoreDiscount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptImage { get; set; }
        public decimal DiscountPreceint { get; set; }
        public bool enabled { get; set; }
        public DateTime? StartDiscount { get; set; }
        public DateTime? EndDiscount { get; set; }
    }
    public class EcommerceStoreDiscountList
    {
       public IEnumerable<Discount> discounts { get; set; }
    }
   
}