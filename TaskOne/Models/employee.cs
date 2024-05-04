using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskOne.Models
{
    public class employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        //may Add Custom Validation for valid is all Digits and lenght =11
        public string Mobile { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public string? ProfileImage { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; } // null?

        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int ModifiedBy { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual User ModifiedByUser { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }

        public Department Department { get; set; }

    }
}

