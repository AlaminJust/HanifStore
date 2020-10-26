using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Domain
{
    public class Order : BaseEntity
    {
        public int ProductId { get; set; }
        public DateTime CratedOn{ get; set; }
        public DateTime UpdatedOn { get; set; } 
        public string VendorId { get; set; }
        public string CustomerId { get; set; }
        public decimal Total { get; set; }    
    }
}
