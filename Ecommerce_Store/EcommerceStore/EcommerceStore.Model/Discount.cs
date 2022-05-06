using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Model
{
    [Table("Discount",Schema ="dbo")]
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptImage { get; set; }
        public decimal DiscountPreceint { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Modified_at { get; set; }
    }
}
