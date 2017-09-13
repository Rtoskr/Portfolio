using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32, ErrorMessage = "The name is too long.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxLength(256, ErrorMessage = "The description is too long.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}