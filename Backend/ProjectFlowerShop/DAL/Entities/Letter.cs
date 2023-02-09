﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.DAL.Entities
{
    public class Letter
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
