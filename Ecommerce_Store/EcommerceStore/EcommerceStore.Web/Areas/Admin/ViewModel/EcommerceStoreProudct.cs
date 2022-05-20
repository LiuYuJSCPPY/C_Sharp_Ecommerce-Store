using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceStore.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace EcommerceStore.Web.Areas.Admin.ViewModel
{
    public class EcommerceStoreProudct
    {
    }

    public class EcommerceStoreProudctList
    {
        public IEnumerable<Proudct> Proudcts { get; set; }
 
    }
}