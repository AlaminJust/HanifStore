using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using HanifStore.Admin.Models;
using HanifStore.Domain;
using HanifStore.Factory;
using HanifStore.Infrustracture.Cache;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace HanifStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IMemoryCache _memoryCache;
        public HomeController
            (
                ILogger<HomeController> logger,
                IProductService productService, 
                IProductModelFactory productModelFactory,
                IMemoryCache memoryCache 
            )
        {
            _logger = logger;
            _productService = productService;
            _productModelFactory = productModelFactory;
            _memoryCache = memoryCache;
        }
        public IActionResult Index(int categoryId = 0)
        {
            var key1 = String.Format(CacheEventConsumer.getProductByCategoryKey, categoryId, User.Identity.Name);
            List<ProductModel> productModels;
            if (!_memoryCache.TryGetValue(key1 ,out productModels))
            {
                var productslist = _productService.getProductByCategoryIdList(categoryId: categoryId, publish: false);
                _memoryCache.Set(key1, _productModelFactory.getProductModelList(productslist));
            }
            productModels = _memoryCache.Get(key1) as List<ProductModel>;
            return View(productModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
