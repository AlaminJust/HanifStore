using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Admin.Models
{
    public class CustomerBuyModel
    {
        [DisplayName("Description(বিবরণ)")]
        public string Description { get; set; }
        [DisplayName("Price(মূল্য)")]
        public decimal Price { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Deposite(জমা)")]
        public decimal Deposite { get; set; }  
    }
}
