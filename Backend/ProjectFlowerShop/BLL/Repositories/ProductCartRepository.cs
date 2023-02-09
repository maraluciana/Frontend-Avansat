using Microsoft.EntityFrameworkCore;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.DAL;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Repositories
{
    public class ProductCartRepository : IProductCartRepository
    {
        private readonly ProjectContext db;
        public ProductCartRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Product> GetAllProdFromShCart(int id)
        {
            var prodscart = db.ProductCart.Where(x => x.CartId == id).ToList();
            List<int> ProdIds = new List<int>();

            foreach(var prod in prodscart)
            {
                ProdIds.Add(prod.ProductId);
            }

            var products = db.Products
                .Where(x => ProdIds.Contains(x.Id));

            return products;
        }

        public ProductCart GetProdCartByIds(int prodId, int cartId)
        {
            var prodcart = db.ProductCart
                .Where(x => x.ProductId == prodId)
                .FirstOrDefault(x => x.CartId == cartId);

            return prodcart;
        }
        public void CreateProdCart(ProductCart prodcart)
        {
            db.ProductCart.Add(prodcart);
            db.SaveChanges();
        }
        public void UpdateProdCart(ProductCart prodcart)
        {

            db.ProductCart.Update(prodcart);
            db.SaveChanges();
        }

        public void DeleteProdCart(ProductCart prodcart)
        {
            db.ProductCart.Remove(prodcart);
            db.SaveChanges();
        }
    }
}
