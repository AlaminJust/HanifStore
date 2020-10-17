using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Admin.Models
{
    public class TransactionListModel
    {
        public string UserId { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public Decimal Deposite { get; set; } 
        public string AddedBy { get; set; } 
    }
}
