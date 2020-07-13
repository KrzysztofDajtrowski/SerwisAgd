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
        public string OrderDescryption { get; set; }
        [Required]
        public string OrderName { get; set; }
        public string OrderState { get; set; }
        public string NewOrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
}