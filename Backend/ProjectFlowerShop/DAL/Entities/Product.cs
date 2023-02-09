using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string productType { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Path{ get; set; }
        public List<ProductCart> ProductCarts { get; set; }

    }
}
