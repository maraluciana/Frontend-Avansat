using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IDiscountService
    {
        List<Discount> GetAllDiscounts();
        List<Discount> GetDiscountsByType(string type);
        void CreateDiscount(DiscountModel model);
        void DeleteDiscount(int id);
        Discount GetDiscountsByCode(string code);
    }
}
