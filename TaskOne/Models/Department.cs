using System.ComponentModel.DataAnnotations;

namespace TaskOne.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [MinLength(5)]
        [MaxLength(500)]
        public string? Description { get; set; }

        public ICollection<employee> Employees { get; set; }
    }
}
