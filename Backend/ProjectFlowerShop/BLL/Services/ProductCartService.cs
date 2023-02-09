using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Services
{
    public class ProductCartService : IProductCartService
    {
        private readonly IProductCartRepository prcartRepository;
        private readonly IProductRepository productRepository;
        private readonly IShoppingCartRepository shcartRepository;

        public ProductCartService(IProductCartRepository prcartRepository, IProductRepository productRepository, IShoppingCartRepository shcartRepository)
        {
            this.prcartRepository = prcartRepository;
            this.productRepository = productRepository;
            this.shcartRepository = shcartRepository;
        }

        public List<Product> GetAllProdFromShCart(int id)
        {
            return prcartRepository.GetAllProdFromShCart(id).ToList();
        }

        public void AddProductToShCart(ProductCartModel model)
        {
            var prodcart = new ProductCart();
            prodcart.ProductId = model.ProductId;
            prodcart.CartId = model.CartId;

            prcartRepository.CreateProdCart(prodcart);

            var product = productRepository.GetProductById(model.ProductId);
            var shcart = shcartRepository.GetShCartById(model.CartId);

            shcart.totalPrice = shcart.totalPrice + product.Price;

            shcartRepository.UpdateShCart(shcart);

        }

        public void DeleteProductFromShCart(ProductCartModel model)
        {
            var prodcart = prcartRepository.GetProdCartByIds(model.ProductId, model.CartId);

            prcartRepository.DeleteProdCart(prodcart);

        }
    }
}
