using Microsoft.EntityFrameworkCore;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository shcartRepository;
        private readonly IDiscountRepository discRepository;
        private readonly ILetterRepository letterRepository;
        private readonly ProjectContext db;

        public ShoppingCartService(IShoppingCartRepository shcartRepository, IDiscountRepository discRepository, ILetterRepository letterRepository, ProjectContext db)
        {
            this.shcartRepository = shcartRepository;
            this.discRepository = discRepository;
            this.letterRepository = letterRepository;
            this.db = db;
        }

        public List<ShoppingCart> GetAllShCarts()
        {
            return shcartRepository.GetAllShCartsIQueryable().ToList();
        }
        public ShoppingCart GetShCartsById(int id)
        {
            return shcartRepository.GetShCartById(id);
        }

        public void CreateShCart()
        {
            var newShCart = new ShoppingCart();

            newShCart.totalPrice = 0;
            shcartRepository.CreateShCart(newShCart);
        }

        public void AddDiscountToShCart(ShCartDiscountModel model)
        {

            var shcart = shcartRepository.GetShCartById(model.idShCart);
            Discount discount = discRepository.GetDiscountByCode(model.codeName);
            
            if(discount != null)
                shcart.DiscountId = discount.Id;

            shcartRepository.UpdateShCart(shcart);
        }
        
        public void AddLetterToShCart(LetterModel model)
        {

            var shcart = shcartRepository.GetShCartById(model.cartId);
            Letter letter = letterRepository.GetLetterById(model.letterId);

            if (letter != null)
                shcart.LetterId = letter.Id;

            shcartRepository.UpdateShCart(shcart);
        }

        public void DeleteShCart(int id)
        {
            var shcart = shcartRepository.GetShCartById(id);
            shcartRepository.DeleteShCart(shcart);
        }

        public float GetFinalPriceOfShCart(int id)
        {
            var shcart = shcartRepository.GetShCartById(id);
            var discount = shcart.Discount;

            var finalPrice = shcart.totalPrice;

            if (discount != null)
            {
                if (discount.discountType == "percentage")
                {
                    finalPrice = finalPrice * (1 - discount.Value / 100);
                }
                else //amount
                {
                    finalPrice = finalPrice - discount.Value;
                    if (finalPrice < 0)
                        finalPrice = 0;
                }
            }

            return finalPrice;
        }
    }
}
