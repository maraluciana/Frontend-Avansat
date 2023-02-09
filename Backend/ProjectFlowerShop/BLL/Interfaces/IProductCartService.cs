using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IProductCartService
    {
        void AddProductToShCart(ProductCartModel model);
        void DeleteProductFromShCart(ProductCartModel model);
        List<Product> GetAllProdFromShCart(int id);
    }
}
