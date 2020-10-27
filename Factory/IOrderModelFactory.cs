using HanifStore.Client.Models;
using HanifStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public interface IOrderModelFactory
    {
        public ShoppingCartItem GetShoppingCartItem(ShoppingCartItemModel model , string vendorId);
        public IList<ShoppingCartItemModel> getShoppingCartItemsModel(IList<ShoppingCartItem> shoppingCartItems);
    }
}
