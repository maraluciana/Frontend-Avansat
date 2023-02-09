using Microsoft.EntityFrameworkCore;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectContext db;
        public ProductRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Product> GetAllProductsIQueryable()
        {
            var products = db.Products.Include(x => x.ProductCarts)
                .OrderBy(x => x.Name);

            return products;
        }

        public IQueryable<Product> GetProductsByTypeIQueryable(string type)
        {
            var products = GetAllProductsIQueryable().Include(x => x.ProductCarts)
                .Where(x => x.productType == type);

            return products;
        }

        public Product GetProductById(int id)
        {
            var product = db.Products.Include(x => x.ProductCarts)
                .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public void CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

    }
}
