using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface IDiscountRepository
    {
        IQueryable<Discount> GetAllDiscountsIQueryable();
        IQueryable<Discount> GetDiscountsByTypeIQueryable(string type);
        Discount GetDiscountById(int id);
        void CreateDiscount(Discount discount);
        void DeleteDiscount(Discount discount);
        public Discount GetDiscountByCode(string code);
        void UpdateDiscount(Discount discount);
    }
}
