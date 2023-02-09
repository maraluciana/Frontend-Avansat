using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.BLL.Repositories;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IShoppingCartRepository
    {
        IQueryable<ShoppingCart> GetAllShCartsIQueryable();
        ShoppingCart GetShCartById(int id);
        void UpdateShCart(ShoppingCart shcart);
        void CreateShCart(ShoppingCart shcart);
        void DeleteShCart(ShoppingCart shcart);
    }
}
