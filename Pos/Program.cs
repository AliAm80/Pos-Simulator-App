using System;

namespace Pos
{
    class Program
    {
        static void Main(string[] args)
        {
            var flag = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t\tWelcome To The Pos Simulator ...");
                Console.ResetColor();
                IPosService transaction = new TransactionService();
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
                    Console.WriteLine(transaction.DataChecker());
                    transaction.AddTransaction();
                }
                Console.Write("Do you want to continue (yes/no)? ");
                flag = Console.ReadLine().ToLower() == "yes";
                
            } while (flag);
            Console.Clear();
            Console.WriteLine("Thanks For Using :)");
        }
    }
}