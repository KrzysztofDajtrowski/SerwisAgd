using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisAGD.Models
{
    public class LoginModel
    {
        public int UserID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email jest wymagany")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres Email: ")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Hasło: ")]

        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}