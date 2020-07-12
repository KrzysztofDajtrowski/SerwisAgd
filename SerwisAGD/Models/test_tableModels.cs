using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerwisAGD.Models
{
    public class test_tableModels
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string Name { get; set;}
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }
    }
}