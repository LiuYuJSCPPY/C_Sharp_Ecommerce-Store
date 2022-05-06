using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Model
{
    [Table("CartItem",Schema ="dbo")]
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int ProudctId { get; set; }
        public virtual Proudct Proudct { get; set; }
        public int Quantity { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Modified_at { get; set; }
    }
}
