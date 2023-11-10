﻿using System;

namespace Pos
{
  class Program
  {
    static void Main(string[] args)
    {

      var flag = true;
      do
      {
        try
        {
          Console.Clear();
          IPosService transaction = new TransactionService();
          var operation = View.Menu();
          Console.Clear();
          switch (operation)
          {
            case "1":
              transaction.GetData();
              if (transaction.DataValidation() == false)
              {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : You Entered Wrong Data !!!");
                Console.WriteLine("Please Try Again :(");
                Console.ResetColor();
              }
              else
              {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(transaction.DataChecker());
                Console.ResetColor();
                transaction.AddTransaction();
              }
              break;
            case "2":
              var select = View.TransactionMenu();
              Console.Clear();
              transaction.ShowTransactionList(select);
              break;
            default:
              throw new Exception("Error : You Entered Wrong Item!");
          }
          Console.Write("Do you want to continue (yes/no)? ");
          flag = Console.ReadLine().ToLower() == "yes";

        }
        catch (Exception ex)
        {
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(ex.Message);
          Console.ReadKey();
          Console.ResetColor();
        }
      } while (flag);

      Console.Clear();
      Console.WriteLine("Thanks For Using :)");
    }
  }
}