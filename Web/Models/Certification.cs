using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Certification
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(64, ErrorMessage = "The name is too long.")]
        public string Name { get; set; }

        [Display(Name = "Authority")]
        [MaxLength(128,ErrorMessage = "The name of the authority is too long.")]
        public string Issuer { get; set; }

        [Display(Name = "Certificate URL")]
        [MaxLength(512,ErrorMessage = "The certificate URL is too long.")]
        public string LinkUrl { get; set; }
    }
}