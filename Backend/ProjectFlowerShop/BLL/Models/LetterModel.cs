using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Models
{
    public class LetterModel
    {
        public int letterId { get; set; }
        public int cartId { get; set; }
        public string Message { get; set; }
    }
}
