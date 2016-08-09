using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrunchyGranola2.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]    
        public int ProductID { get; set; }
        public int Price { get; set; }
        public int UpcCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string LeadTime { get; set; }

        public virtual ICollection<Purchase>Purchases { get; set; }
    }
}