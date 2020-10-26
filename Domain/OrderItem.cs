using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Domain
{
    public class OrderItem : BaseEntity
    {
        public int OderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string VendorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal Subtotal { get; set; }
        public string AttributeXml { get; set; }
    }
}
