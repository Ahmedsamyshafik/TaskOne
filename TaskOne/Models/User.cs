using System.ComponentModel.DataAnnotations;

namespace TaskOne.Models
{

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        [MinLength(3)]
        public string Password { get; set; } // Hash?

        public ICollection<employee>? CreatedEmployees { get; set; }
        public ICollection<employee>? ModifiedEmployees { get; set; }
    }
}
