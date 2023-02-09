using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.BLL.Repositories;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IShoppingCartService
    {
        public void DeleteShCart(int id);
        void AddDiscountToShCart(ShCartDiscountModel model);
        void AddLetterToShCart(LetterModel model);
        List<ShoppingCart> GetAllShCarts();
        ShoppingCart GetShCartsById(int id);
        void CreateShCart();
        float GetFinalPriceOfShCart(int id);
    }
}
