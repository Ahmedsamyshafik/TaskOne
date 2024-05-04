using System.ComponentModel.DataAnnotations;

namespace TaskOne.ViewModel
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
