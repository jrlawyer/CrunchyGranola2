using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrunchyGranola2.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set;}

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        public virtual Department Department { get; set; }

    }
}