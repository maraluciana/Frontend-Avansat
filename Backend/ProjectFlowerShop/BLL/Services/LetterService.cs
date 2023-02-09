using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Services
{
    public class LetterService : ILetterService
    {
        private readonly ILetterRepository letterRepository;

        public LetterService(ILetterRepository letterRepository)
        {
            this.letterRepository = letterRepository;
        }

        public List<Letter> GetAllLetters()
        {
            return letterRepository.GetAllLettersIQueryable().ToList();
        }

        public void UpdateLetter(LetterModel model)
        {
            var letter = letterRepository.GetLetterById(model.letterId);
            if (model.Message != "")
                letter.Message = model.Message;

            letterRepository.UpdateLetter(letter);
        }

        public void CreateLetter(LetterModel model)
        { 
            var newLetter = new Letter();            
            newLetter.Message = model.Message;

            letterRepository.CreateLetter(newLetter);
        }

         public void DeleteLetter(int id)
         {
             var letter = letterRepository.GetLetterById(id);
             letterRepository.DeleteLetter(letter);
         }
    }
}
