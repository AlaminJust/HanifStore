﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Domain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string ProductSpecificationIds { get; set; }
        public int CategoryId { get; set; }
        public bool IsPublish { get; set; }
        public bool IsDeleted { get; set; }
        public int DisplayOrder { get; set; }
        public string ProductPicture { get; set; }
        public string VendorId { get; set; }
        public DateTime CreatedOn { get; set; }  
        public virtual IdentityUser IdentityUser { get; set; }
        public Category ProductCategory { get; set; }

    }
}
