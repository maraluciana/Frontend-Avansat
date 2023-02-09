using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface ILetterRepository
    {
        IQueryable<Letter> GetAllLettersIQueryable();
        void UpdateLetter(Letter letter);
        void DeleteLetter(Letter letter);
        void CreateLetter(Letter letter);
        Letter GetLetterById(int id);
    }
}
