using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EcommerceStore.Model
{
    [Table("Order",Schema ="dbo")]
    public class Order
    {
        public int Id { get; set; }

        [Key]
        public string AdminUserId { get; set; }
        [ForeignKey("AdminUserId")]
        public virtual AdminUser adminUser { get; set; }
        public decimal Total { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
