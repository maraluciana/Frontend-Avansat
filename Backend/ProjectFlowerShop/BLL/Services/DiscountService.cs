using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }

        public List<Discount> GetAllDiscounts()
        {
            return discountRepository.GetAllDiscountsIQueryable().ToList();
        }
        public List<Discount> GetDiscountsByType(string type)
        {
            return discountRepository.GetDiscountsByTypeIQueryable(type).ToList();
        }

        public Discount GetDiscountsByCode(string code)
        {
            return discountRepository.GetDiscountByCode(code);
        }

        public void CreateDiscount(DiscountModel model)
        {
            var newDiscount = new Discount();

             newDiscount.discountType = model.discountType;
             newDiscount.codeName = model.codeName;
             newDiscount.Value = model.Value;

            discountRepository.CreateDiscount(newDiscount);
        }

        public void DeleteDiscount(int id)
        {
            var discount = discountRepository.GetDiscountById(id);
            discountRepository.DeleteDiscount(discount);
        }
    }
}
