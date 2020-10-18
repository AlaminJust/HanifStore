using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HanifStore.Factory;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HanifStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IProductModelFactory _productModelFactory;

        public HomeController
            (
                ILogger<HomeController> logger,
                IProductService productService, 
                IProductModelFactory productModelFactory
            )
        {
            _logger = logger;
            _productService = productService;
            _productModelFactory = productModelFactory;
        }

        public IActionResult Index()
        {
            var products = _productService.getProductByCategoryIdList();
            var productListModel = _productModelFactory.getProductModelList(products);
            return View(productListModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
