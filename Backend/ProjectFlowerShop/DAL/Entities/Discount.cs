using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.DAL.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string codeName { get; set; }
        public string discountType { get; set; }
        public float Value { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
