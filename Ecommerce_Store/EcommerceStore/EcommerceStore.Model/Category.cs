using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Model
{
    [Table("Category",Schema ="dbo")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryImage { get; set; }

        public ICollection<Proudct> Proudcts { get; set; }
    }
}
