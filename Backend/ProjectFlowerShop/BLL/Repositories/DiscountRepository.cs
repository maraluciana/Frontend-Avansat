using Microsoft.EntityFrameworkCore;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.DAL;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ProjectContext db;
        public DiscountRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Discount> GetAllDiscountsIQueryable()
        {
            var discounts = db.Discounts
                .Include(x => x.ShoppingCarts)
                .OrderBy(x => x.Id); 

            return discounts;
        }

        public IQueryable<Discount> GetDiscountsByTypeIQueryable(string type)
        {
            var discounts = GetAllDiscountsIQueryable()
                .Include(x => x.ShoppingCarts)
                .Where(x => x.discountType == type);

            return discounts;
        }

        public Discount GetDiscountById(int id)
        {
            var discount = db.Discounts
                .Include(x => x.ShoppingCarts)
                .FirstOrDefault(x => x.Id == id);

            return discount;
        }

        public Dictionary<float, List<Discount>> GroupDiscountsComparedToValue(float value)
        {
            var groupedDiscounts = db.Discounts.Where(d => d.Value >= value)
                .GroupBy(d => d.Value)
                .ToDictionary(g => g.Key, g => g.ToList());

            return groupedDiscounts;
        }

        public Discount GetDiscountByCode(string code)
        {
            var discount = db.Discounts
                .Include(x => x.ShoppingCarts)
                .FirstOrDefault(x => x.codeName == code);

            return discount;
        }

        public void UpdateDiscount(Discount discount)
        {
            db.Discounts.Update(discount);
            db.SaveChanges();
        }

        public void CreateDiscount(Discount discount)
        {
            db.Discounts.Add(discount);
            db.SaveChanges();
        }

        public void DeleteDiscount(Discount discount)
        {
            db.Discounts.Remove(discount);
            db.SaveChanges();
        }
    }
}
