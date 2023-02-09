using Microsoft.EntityFrameworkCore;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ProjectContext db;
        public ShoppingCartRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<ShoppingCart> GetAllShCartsIQueryable()
        {
            var shcarts = db.ShoppingCarts
                .Include(x => x.Discount)
                .Include(x => x.ProductCarts)
                .Include(x => x.Letter)
                .OrderBy(x => x.Id);

            return shcarts;
        }

        public ShoppingCart GetShCartById(int id)
        {
            var shcart = db.ShoppingCarts
                .Include(x => x.Discount)
                .Include(x => x.Letter)
                .FirstOrDefault(x => x.Id == id);

            return shcart;
        }

        public void CreateShCart(ShoppingCart shcart)
        {            
            db.ShoppingCarts.Add(shcart);
            db.SaveChanges();
        }

        public void UpdateShCart(ShoppingCart shcart)
        {

            db.ShoppingCarts.Update(shcart);
            db.SaveChanges();
        }

        public void DeleteShCart(ShoppingCart shcart)
        {
            db.ShoppingCarts.Remove(shcart);
            db.SaveChanges();
        }
    }
}
