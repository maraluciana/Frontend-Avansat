using Microsoft.EntityFrameworkCore;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Repositories
{
    public class LetterRepository : ILetterRepository
    {
        private readonly ProjectContext db;
        public LetterRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Letter> GetAllLettersIQueryable()
        {
            var letters = db.Letters
                .OrderBy(x => x.Id);

            return letters;
        }

        public Letter GetLetterById(int id)
        {
            var letter = db.Letters
                .FirstOrDefault(x => x.Id == id);

            return letter;
        }

        public (string,int) JoinLetterToShoppingCart(int id)
        {
            var result = db.Letters
                   .Join(db.ShoppingCarts,
                         l => l.Id,
                         s => s.LetterId,
                         (l, s) => new { l, s })
                   .FirstOrDefault(x => x.s.Id == id);

            var message = result.l.Message;

            return (message,id);
        }

        public void UpdateLetter(Letter letter)
        {
            db.Letters.Update(letter);
            db.SaveChanges();
        }

        public void CreateLetter(Letter letter)
        {
            db.Letters.Add(letter);
            db.SaveChanges();
        }

        public void DeleteLetter(Letter letter)
        {
            db.Letters.Remove(letter);
            db.SaveChanges();
        }
    }
}
