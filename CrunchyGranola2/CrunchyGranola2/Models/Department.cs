using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrunchyGranola2.Models
{
    public class Department
    {
        [Display(Name = "Department ID")]
        public int DepartmentID { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        
        [ForeignKey("Manager")]
        public int? EmployeeID { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Product>Products { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}