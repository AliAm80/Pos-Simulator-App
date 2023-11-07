using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Pos
{
    public class TransactionService : IPosService
    {
        private string _amount;
        private string _cardNumber;
        private string _cvv2;
        private string _expiredDate;
        private string _dynamicPass;
        private string _transactionResult;
        private List<string> _transactionList;
        private List<string> _passwordList;
        private List<string> _cardInfoList;
        private string _transactionFilePath = @"Enter your path file";
        private string _dynamicPassFilePath = @"Enter your path file";
        private string _cardInfoFilePath = @"Enter your path file";
        private FileData _file;
        public TransactionService()
        {
            _file = new FileData();
            _transactionList = new List<string>();
            _passwordList = new List<string>();
            _cardInfoList = new List<string>();
            _file.ReadData(_transactionFilePath, _transactionList);
            _file.ReadData(_dynamicPassFilePath, _passwordList);
            _file.ReadData(_cardInfoFilePath, _cardInfoList);
        }
        public void GetData()
        {
            // Get Data For Transaction
            Console.Write("Enter Amount : ");
            _amount = Console.ReadLine();
            Console.Write("Enter Card Number : ");
            _cardNumber = Console.ReadLine();
            Console.Write("Enter CVV2 : ");
            _cvv2 = Console.ReadLine();
            Console.Write("Enter Expired Date : ");
            _expiredDate = Console.ReadLine();
            Console.Write("Enter Dynamic Password : ");
            _dynamicPass = Console.ReadLine();
        }


        public bool DataValidation()
        {
            // Validate inputs Data (Total)
            var checkCardNumber = double.TryParse(_cardNumber, out _);
            var checkCvv2 = int.TryParse(_cvv2, out _);
            var checkDynamicPass = int.TryParse(_dynamicPass, out _);
            var checkAmount = double.TryParse(_amount, out _);
            var checkExDate = false;
            foreach (var character in _expiredDate)
            {
                if (character != '/')
                    checkExDate = char.IsDigit(character);
                if (checkExDate == false)
                    break;
            }

            if (_amount == null || _cardNumber == null ||
                _dynamicPass == null || _cvv2 == null ||
                _expiredDate == null)
                return false;
            else if (_cardNumber.Length != 16 || _dynamicPass.Length != 6 ||
                     _cvv2.Length != 4 || _expiredDate.Length != 5 ||
                     checkCardNumber == false || checkCvv2 == false ||
                     checkExDate == false || checkAmount == false ||
                     checkDynamicPass == false)
                return false;
            else
                return true;
        }



        public string DataChecker()
        {
            // Validate Input Data With DynamicPassword And CardsInfo Files
            var dpfCardNumber = _passwordList.Where(x => x.Length == 16)
                                             .Contains(_cardNumber);
            var dpfPassword = _passwordList.Where(x => x.Length == 6)
                                             .Contains(_dynamicPass);
            var cifCvv2 = _cardInfoList.Where(x => x.Length == 4)
                                       .Contains(_cvv2);
            var cifExDate = _cardInfoList.Where(x => x.Length == 5)
                                         .Contains(_expiredDate);
            if (dpfCardNumber == true && dpfPassword == true &&
                cifCvv2 == true && cifExDate == true)
                _transactionResult = "The Transaction Was Done Successfully...";
            else
                _transactionResult = "The Transaction Failed !!!";
            return _transactionResult;
        }

        public void AddTransaction()
        {
            // Add Transaction Data on _transactionList And Save on file
            var key = _transactionList.Count / 5;
            _transactionList.Add((++key).ToString());
            _transactionList.Add(_cardNumber);
            _transactionList.Add(_amount);
            _transactionList.Add(_transactionResult);
            _transactionList.Add("---");
            _file.SaveData(_transactionFilePath, _transactionList);
        }

    }
}