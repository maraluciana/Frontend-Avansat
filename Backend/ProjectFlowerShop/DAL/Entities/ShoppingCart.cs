using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.DAL
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }
        [ForeignKey("Letter")]
        public int? LetterId { get; set; }
        public float totalPrice { get; set; }
        public Discount Discount { get; set; }
        public Letter Letter { get; set; }
        public List<ProductCart> ProductCarts { get; set; }
    }
}
