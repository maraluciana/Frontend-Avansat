using ProjectFlowerShop.DAL;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IProductCartRepository
    {
        public void CreateProdCart(ProductCart prodcart);
        public void UpdateProdCart(ProductCart prodcart);
        public void DeleteProdCart(ProductCart prodcart);
        ProductCart GetProdCartByIds(int prodId, int cartId);
        IQueryable<Product> GetAllProdFromShCart(int id);
    }
}
