using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos
{
  public static class View
  {
    public static string Menu()
    {

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\t\t\t\tWelcome To The Pos Simulator ...");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("<Menu>");
      Console.ResetColor();
      Console.WriteLine("1) Buy the product");
      Console.WriteLine("2) Show Transaction");
      Console.Write("Select the operation : ");
      return Console.ReadLine();
    }
    public static string TransactionMenu()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("<Transaction Menu>");
      Console.ResetColor();
      Console.WriteLine("1- Show Successful Transactions");
      Console.WriteLine("2- Show Failed Transactions");
      Console.Write("Select a item -> ");
      return Console.ReadLine();
    }
  }
}