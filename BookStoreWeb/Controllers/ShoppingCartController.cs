using BusinessLayer.Services.ShoppingCartService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public ActionResult MyCart()
        {
            var shoppingCartId = _shoppingCartService.GetShoppingCartId(User.Identity.GetUserId());

            var cartItems = _shoppingCartService.GetCartItems(shoppingCartId);

            var totalAmount = cartItems.Sum(x => x.Subtotal);
            ViewBag.GrandTotal = totalAmount;

            return View(cartItems);
        }

        public ActionResult AddToCart(int productId, int quantity = 1)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated == false)
            {
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }

            var shoppingCartId = _shoppingCartService.GetShoppingCartId(User.Identity.GetUserId());

            var result = _shoppingCartService.AddItemToCart(productId, shoppingCartId,quantity);

            if(result == -1)
            {
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
    }
}