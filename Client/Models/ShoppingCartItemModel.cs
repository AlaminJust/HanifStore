using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Client.Models
{
    public class ShoppingCartItemModel
    {
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public string VendorId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string AttributeXml { get; set; }
        public decimal Subtotal { get; set; }
    }
}
