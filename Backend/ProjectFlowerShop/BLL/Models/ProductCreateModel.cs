using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Models
{
    public class ProductCreateModel
    {
        public int Id { get; set; }
        public string productType { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Path { get; set; }
    }
}
