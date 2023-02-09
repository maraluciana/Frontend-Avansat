using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Interfaces
{
    public interface ILetterService
    {
        List<Letter> GetAllLetters();
        void CreateLetter(LetterModel model);
        void DeleteLetter(int id);
        void UpdateLetter(LetterModel model);
    }
}
