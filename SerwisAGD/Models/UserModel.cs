using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisAGD.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage ="Imie jest wymagane")]
        [Display(Name="Imię: ")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Imie jest wymagane")]
        [Display(Name="Nazwisko: ")]
        public string Surname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Numer telefonu jest wymagany")]
        [Display(Name = "Numer telefonu: ")]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email jest wymagany")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres Email: ")]

        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Miasto jest wymagane")]
        [Display(Name = "Miasto zamieszkania: ")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kod pocztowy jest wymagany")]
        [Display(Name = "Kod pocztowy: ")]
        public string ZipCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adres jest wymagany")]
        [Display(Name = "Adres zamieszkania: ")]
        public string Adress { get; set; }
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Hasło: ")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Powtórzenie hasła jest wymagane")]
        [Display(Name = "Powtórz hasło: ")]
        [Compare("Password", ErrorMessage ="Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
        public string UserRole { get; set; }
        
}
}