using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicPassword
{
    public class CardService : ICardService
    {
        private string _cardInfoFilePath = @"Enter your file path";
        private string _dynamicPassFilePath = @"Enter your file path";
        private string _cardNumber;
        private string _cvv2;
        private string _expiredDate;
        private List<string> _cardInfoList;
        private List<string> _passList;
        private IFileData _file;
        private Random random;
        public CardService(IFileData _file)
        {
            // Dependency Injection
            this._file = _file;
            random = new Random();
            _cardInfoList = new List<string>();
            _passList = new List<string>();
            _file.ReadData(_cardInfoFilePath, _cardInfoList);
        }
        public void GetInfoCard()
        {
            // Get Card Informations By User
            Console.Write("Enter Card Number : ");
            _cardNumber = Console.ReadLine();
            Console.Write("Enter CVV2 : ");
            _cvv2 = Console.ReadLine();
            Console.Write("Enter Expired Date (year/month): ");
            _expiredDate = Console.ReadLine();
        }
        public bool DataValidation()
        {
            // Validate User's Card Information
            var checkCardNumber = double.TryParse(_cardNumber, out _);
            var checkCvv2 = int.TryParse(_cvv2, out _);
            var checkExDate = false;
            foreach (var character in _expiredDate)
            {
                if (character != '/')
                    checkExDate = char.IsDigit(character);
                if (checkExDate == false)
                    break;
            }
            if (_cardNumber == null || _cvv2 == null || _expiredDate == null)
                return false;
            else if (_cardNumber.Length != 16 ||
                     _cvv2.Length != 4 ||
                     checkCardNumber == false ||
                     checkCvv2 == false ||
                     checkExDate == false ||
                     _expiredDate.Length != 5)
                return false;
            return true;
        }
        public void AddCard()
        {
            // Add Card Data on _cardInfoList
            var key = _cardInfoList.Count / 5;
            _cardInfoList.Add((++key).ToString());
            _cardInfoList.Add(_cardNumber);
            _cardInfoList.Add(_cvv2);
            _cardInfoList.Add(_expiredDate);
            _cardInfoList.Add("---");
        }
        public string CreatePass()
        {
            // Create Password By Random Class
            var password = random.Next(100000, 1000000);
            // Add _cardNumber and password on _passList
            _passList.Add(_cardNumber);
            _passList.Add(password.ToString());
            return $"[{_cardNumber}]\nDynamic Password : " + password.ToString();
        }
        public void ShowListOfCards()
        {
            // Validate _cardInfoList and Show List Of Cards  
            if (_cardInfoList.Count == 0)
                throw new Exception("No Card Exists !!!");
            else
            {
                var cards = _cardInfoList.Where(x => x.Length == 16).ToList();
                for (int i = 0; i < cards.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}) {cards[i]}");
                }

                // Error Handling For _cardNumber
                Console.Write("Enter A Number : ");
                try
                {
                    var number = Convert.ToInt32(Console.ReadLine());
                    _cardNumber = cards[number - 1];
                }
                catch (Exception)
                {
                    throw new Exception("Error : You Entered Wrong Item!");
                }
            }
        }

        public bool UpdateCard()
        {
            var indexOfCardNumber = _cardInfoList.IndexOf(_cardNumber);
            Console.WriteLine("<Preview>");
            Console.WriteLine($"1) Card Number : {_cardInfoList[indexOfCardNumber]}");
            Console.WriteLine($"2) CVV2 : {_cardInfoList[indexOfCardNumber + 1]}");
            Console.WriteLine($"3) Expired Date : {_cardInfoList[indexOfCardNumber + 2]}");
            Console.Write("Which one do you wanna changed it ? ");
            var answer = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------");
            switch (answer)
            {
                case "1":
                    Console.Write("Enter Card Number : ");
                    var newCardNumber = Console.ReadLine();
                    var checkCardNumber = double.TryParse(newCardNumber,
                                                          out _);
                    if (checkCardNumber == true && newCardNumber.Length == 16)
                    {
                        _cardInfoList[indexOfCardNumber] = newCardNumber;
                        return true;
                    }
                    return false;
                case "2":
                    Console.Write("Enter CVV2 : ");
                    var newCvv2 = Console.ReadLine();
                    var checkCvv2 = int.TryParse(newCvv2,
                                                 out _);
                    if (checkCvv2 == true && newCvv2.Length == 4)
                    {
                        _cardInfoList[indexOfCardNumber + 1] = newCvv2;
                        return true;
                    }
                    return false;
                case "3":
                    Console.Write("Enter Expired Date : ");
                    var newExDate = Console.ReadLine();
                    var checkExDate = false;

                    foreach (var character in _expiredDate)
                    {
                        if (character != '/')
                            checkExDate = char.IsDigit(character);
                        if (checkExDate == false)
                            break;
                    }
                    if (checkExDate == true && newExDate.Length == 5)
                        _cardInfoList[indexOfCardNumber + 2] = newExDate;
                    return checkExDate;
                default:
                    throw new Exception("Error : You Entered Wrong Item!");
            }
        }

        public void RemoveCard()
        {
            var indexOfkey = _cardInfoList.IndexOf(_cardNumber) - 1;
            var key = int.Parse(_cardInfoList[indexOfkey]);
            for (int i = 0; i < 5; i++)
            {
                _cardInfoList.RemoveAt(indexOfkey);
            }

            for (int i = indexOfkey; i < _cardInfoList.Count; i += 5)
            {
                _cardInfoList[i] = (key++).ToString();
            }
        }

        public void Save()
        {
            _file.SaveData(_cardInfoFilePath, _cardInfoList);
            _file.SaveData(_dynamicPassFilePath, _passList);
        }
    }
}
