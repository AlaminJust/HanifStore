using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Domain
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } 
        public string CreatedBy { get; set; }
        public bool IsPublish { get; set; }
        public int DisplayOrder { get; set; } 
        public DateTime CreatedOn { get; set; } 
    }
}
