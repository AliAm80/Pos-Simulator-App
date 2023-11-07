using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicPassword
{
    public interface ICardService
    {
        public void GetInfoCard();
        public void AddCard();
        public bool DataValidation();
        public bool UpdateCard();
        public void RemoveCard();
        public void ShowListOfCards();
        public string CreatePass();
        public void Save();
    }
}