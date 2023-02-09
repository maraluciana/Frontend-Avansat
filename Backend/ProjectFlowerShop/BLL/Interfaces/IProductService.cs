using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetProductsByType(string type);
        Product GetProductById(int id);
        void CreateProduct(ProductCreateModel model);
        void UpdateProduct(ProductUpdateModel model);
        void DeleteProduct(int id);
    }
}
