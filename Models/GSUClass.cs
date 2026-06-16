using System.ComponentModel.DataAnnotations;

namespace ClassRegistration.Models
{
    public class GSUClass
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please enter a class name.")]
        [Display(Name = "Class Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a class number.")]
        [Display(Name = "Class Number")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a department.")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter credit hours.")]
        public int? Credit { get; set; }

        [Required(ErrorMessage = "Please enter capacity.")]
        public int? Capacity { get; set; }
    }
}
