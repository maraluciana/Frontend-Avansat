using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Models
{
    public class DiscountModel
    {
        public int Id { get; set; }
        public string discountType { get; set; }
        public string codeName { get; set; }
        public float Value { get; set; }
    }
}
