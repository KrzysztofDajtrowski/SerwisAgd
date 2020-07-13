using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SerwisAGD.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }
        
        public int UserID { get; set; }
        [Required]
        [Display(Name="Opis usługi: ")]
        public string OrderDescryption { get; set; }
        [Required]
        [Display(Name="Tutuł usługi: ")]
        public string OrderName { get; set; }
        [Display(Name="Stan: ")]
        public string OrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
}