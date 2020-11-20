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
        private readonly IUserService _userService;

        public OrdersController
            (
                IProductService productService,
                IOrderService orderService,
                IOrderModelFactory orderModelFactory,
                IUserService userService
            )
        {
            _productService = productService;
            _orderService = orderService;
            _orderModelFactory = orderModelFactory;
            _userService = userService;
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
        [Route("cart")]
        public IActionResult Cart()
        {
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userName: User.Identity.Name);
            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            var shoppingCartItem = _orderService.getShoppingCartByCustomerId(user.Id);
            var model = _orderModelFactory.getShoppingCartItemsModel(shoppingCartItem).ToList();
            return View("~/Client/Views/Order/Cart.cshtml", model);
        }
        [Route("remove")]
        [HttpPost]
        public IActionResult DeleteItemFromCart(ShoppingCartItemModel model)
        {
            _orderService.DeleteShopingCartItemById(model.Id);
            return Json(new { result = "Your item is removed.", url = Url.Action("cart", "order") });
        }
        [Route("update")]
        [HttpPost]
        public IActionResult UpdateCartItem(ShoppingCartItemModel model)
        {
            _orderService.UpdateShoppingCartItem(model);
            return Json(new { result = "Your item is updated.", url = Url.Action("cart", "order") });
        }
    }
}
