using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskOne.Models;

namespace TaskOne.ViewModel
{
    public class AddEmployeVM
    {
        [Key]

        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        //may Add Custom Validation for valid is all Digits and lenght =11
        public string Mobile { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public int CreatedBy { get; set; }
        public int DepartmentID { get; set; }

    }
}
