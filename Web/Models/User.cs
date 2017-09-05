using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(15,ErrorMessage = "The username you specified is too long.")]
        [MinLength(4,ErrorMessage = "The username you specified is not long enough.")]
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "You specified an invalid e-mail address.")]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public string AvatarUrl { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(128)]
        public string DisplayName { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(1024, ErrorMessage = "Your bio is too long.  The maximum is 1024 characters.")]
        public string Bio { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastLoggedOnDateTime { get; set; }
    }
}