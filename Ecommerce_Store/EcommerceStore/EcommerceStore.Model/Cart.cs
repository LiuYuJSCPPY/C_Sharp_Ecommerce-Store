using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Model
{
    [Table("Cart",Schema ="dbo")]
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("AdminUser")]
        public int AdminUserId { get; set; }
        public virtual AdminUser adminUser { get; set; }
        public decimal Total { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
