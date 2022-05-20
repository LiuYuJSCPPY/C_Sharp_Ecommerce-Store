using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EcommerceStore.Data;
using EcommerceStore.Model;


namespace EcommerceStore.Serivce
{
    public class ProudctService
    {
        public IEnumerable<Proudct> GetAllProuct()
        {
            var context = new EcommerceStoreContext();
            var Prouct = context.Proudcts.Include(p => p.Category).Include(p => p.Discount).ToList();
            return Prouct;
        }
    }
}
