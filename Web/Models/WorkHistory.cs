using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class WorkHistory
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(256, ErrorMessage = "Your employer name is too long.")]
        public string Employer { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(256,ErrorMessage = "Your title is too long.")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(2048,ErrorMessage = "Your description is too long.")]
        public string Description { get; set; }
    }
}