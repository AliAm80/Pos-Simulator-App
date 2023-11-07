using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicPassword
{
    public static class View
    {
        public static string Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tWelcome To The Dynamic Password Maker Simulator ...");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) Add A New Card");
            Console.WriteLine("2) Edit Card");
            Console.WriteLine("3) Remove Card");
            Console.WriteLine("4) Create A Dynamic Password");
            Console.WriteLine("5) Exit");
            Console.ResetColor();
            Console.Write("Please Select Your Operation : ");
            return Console.ReadLine();
        }
    }
}