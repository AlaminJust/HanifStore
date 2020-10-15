using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Domain
{
    public class CustomerDeposit : BaseEntity
    {
        public string Description { get; set; }
        public decimal Money { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

    }
}
