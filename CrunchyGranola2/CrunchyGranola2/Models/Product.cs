using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrunchyGranola2.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Product Number")]
        public int ProductID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public int Price { get; set; }

        [Display(Name = "UPC Code")]
        public int UpcCode { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Lead Time")]
        public string LeadTime { get; set; }

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        [Display(Name = "Department ID")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Purchase>Purchases { get; set; }
    }
}