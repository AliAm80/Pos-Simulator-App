using System;

namespace DynamicPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            ICardService card = new CardService();
            var flag = true;
            do
            {
                try
                {
                    // App Menu
                    var operation = View.Menu();
                    Console.Clear();
                    // Execute The Operation
                    switch (operation)
                    {
                        case "1":
                            card.GetInfoCard();
                            if (card.DataValidation() == false)
                                throw new Exception("Error : You Entered Wrong Card Data !!!\nPlease Try Next Time :(");
                            else
                            {
                                card.AddCard();
                                Console.WriteLine("Data Card Saved Successfully :)");
                            }
                            Console.ReadLine();
                            break;
                        case "2":
                            card.ShowListOfCards();
                            Console.Clear();
                            if (card.UpdateCard() == false)
                                throw new Exception("Error : Please Try Again :(");
                            else
                                Console.WriteLine("Data Card Edited Successfully :)");
                            Console.ReadLine();
                            break;
                        case "3":
                            card.ShowListOfCards();
                            card.RemoveCard();
                            Console.WriteLine("The Card Data Deleted Successfully!");
                            Console.ReadLine();
                            break;
                        case "4":
                            card.ShowListOfCards();
                            Console.Clear();
                            Console.WriteLine(card.CreatePass());
                            Console.ReadLine();
                            break;
                        case "5":
                            Console.WriteLine("Thanks For Using This App, Bye :)");
                            flag = false;
                            break;
                        default:
                            throw new Exception("Error : You Entered Wrong Item!");
                    }

                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.ResetColor();
                }

            } while (flag);
            card.Save();
        }
    }
}
