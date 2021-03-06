﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Domain
{

    public class CustomersBuy : BaseEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Deposite { get; set; } 
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AddedBy { get; set; } 
        public virtual IdentityUser IdentityUser { get; set; } 
    }
}
