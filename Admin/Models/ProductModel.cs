using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Display(Name = "Product name(পণ্যের নাম)")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "Price(মূল্য)")]
        public decimal Price { get; set; }
        [Display(Name = "Quantity(পরিমান)")]
        [Required]
        public decimal Quantity { get; set; }
        public string ProductSpecificationIds { get; set; }
        [Display(Name = "Category name(বিভাগ নাম)")]
        public int CategoryId { get; set; }
        [Display(Name = "Publish(প্রকাশ করুন)")]
        public bool IsPublish { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Display order")]
        public int DisplayOrder { get; set; }
        public string ProductPicture { get; set; }
        public DateTime CreatedOn { get; set; }
        public string VendorId { get; set; }  
    }

    public class ProductsListModel
    {
        public ProductsListModel()
        {
            ProductModel = new ProductModel();
            ProductsModel = new List<ProductModel>();
        }
        public ProductModel ProductModel { get; set; }
        public IList<ProductModel> ProductsModel { get; set; }
    }
}
