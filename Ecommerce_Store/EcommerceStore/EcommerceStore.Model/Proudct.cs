using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Model
{
    [Table("Proudct",Schema ="dbo")]
    public class Proudct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decsription { get; set; }
        public int Stock_Keep { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public decimal price { get; set; }
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        public string ProudctImage { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual ICollection<ProudctImage> ProudctImages { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
