using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Model
{
    [Table("ProudctImage", Schema ="dbo")]
    public class ProudctImage
    {
        public int Id { get; set; }
        public int ProudctId { get; set; }
        public Proudct Proudct { get; set; }

        public string ProudctImagePath { get; set; }

    }
}
