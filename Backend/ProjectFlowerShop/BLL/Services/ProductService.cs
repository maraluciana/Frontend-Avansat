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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProductsIQueryable().ToList();
        }
        public List<Product> GetProductsByType(string type)
        {
            return productRepository.GetProductsByTypeIQueryable(type).ToList();
        }

        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }


        public void CreateProduct(ProductCreateModel model)
        {
            var newProduct = new Product();

            newProduct.productType = model.productType;
            newProduct.Name = model.Name;
            newProduct.Path = model.Path;
            newProduct.Price = model.Price;

            productRepository.CreateProduct(newProduct);
        }

        public void UpdateProduct(ProductUpdateModel model)
        {
            var product = productRepository.GetProductById(model.Id);
            if (model.Name != "")
                product.Name = model.Name;
            if (model.Path != "")
                product.Path = model.Path;
            if (model.Price != 0)
                product.Price = model.Price;

            productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            var product = productRepository.GetProductById(id);
            productRepository.DeleteProduct(product);
        }
    }
}
