using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HanifStore.Client.Models;
using HanifStore.Factory;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Client.Controllers
{
    [Route("order")]
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderModelFactory _orderModelFactory;

        public OrdersController
            (
                IProductService productService,
                IOrderService orderService,
                IOrderModelFactory orderModelFactory
            )
        {
            _productService = productService;
            _orderService = orderService;
            _orderModelFactory = orderModelFactory;
        }
        [Route("addtocart")]
        [HttpPost]
        public IActionResult AddItemToCart(ShoppingCartItemModel model)
        {
            var product = _productService.getProductById(model.ProductId);
            if(product == null)
            {
                throw new NullReferenceException(nameof(product));
            }
            var shoppingCart = _orderModelFactory.GetShoppingCartItem(model , User.Identity.Name);
            _orderService.InsertShoppingCartItem(shoppingCart);
            return Json(new { result = "Product added to the cart." , url = Url.Action("index","home") });
        }
        
    }
}
