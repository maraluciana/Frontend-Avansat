using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.BLL.Repositories;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAllProductsIQueryable();
        IQueryable<Product> GetProductsByTypeIQueryable(string type);
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
