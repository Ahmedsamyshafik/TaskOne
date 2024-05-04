using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskOne.Models;

namespace TaskOne.ViewModel
{
    public class EmployeeEditVM
    {

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
        public decimal Salary { get; set; }
        public string? ProfileImageUrl { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int DepartmentID { get; set; }


    }
}
