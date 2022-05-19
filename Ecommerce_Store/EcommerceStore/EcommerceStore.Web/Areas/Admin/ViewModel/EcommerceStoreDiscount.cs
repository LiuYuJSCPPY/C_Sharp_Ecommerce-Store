using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceStore.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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

       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: yyyy-MMM-dd}",ApplyFormatInEditMode =true)]
        public DateTime StartDiscount { get; set; }

       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MMM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDiscount { get; set; }

        public DateTime? Create_at { get; set; }
    }
    public class EcommerceStoreDiscountList
    {
       public IEnumerable<Discount> discounts { get; set; }
    }
   
}