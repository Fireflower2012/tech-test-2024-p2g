using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go_tech_test
{
     class ConsoleOutText : IOutputText
    {

        public static void DisplayIntroText()
        {
            Console.WriteLine("Parcels2Go Techtest Checkout");
            Console.WriteLine("");
        }


        public static void DisplayExitText()
        {
            Console.WriteLine("Please Proceed to Payment");
        }


        public static void DisplayServiceList()
        {
            Console.WriteLine("Available Services:");
            Console.WriteLine("A: £10 each or 3 for £25");
            Console.WriteLine("B: £12 each or 2 for £20");
            Console.WriteLine("C: £15 each");
            Console.WriteLine("D: £25 each");
            Console.WriteLine("F: £8 each or 2 for £15");
            Console.WriteLine();
            Console.WriteLine("Enter a service letter to add it to the basket");
            Console.WriteLine("Or type checkout to finish");
        }


        public static void DisplayRunningTotal(decimal price)
        {
            Console.WriteLine($"Total price: £{price.ToString("F2")}");
        }


        public static void DisplayInvalidServiceText()
        {
            Console.WriteLine("Item not recognised");
            Console.WriteLine("Enter a service or type exit to quit");
        }


        public static void DisplayBasketSummaryText(Dictionary<string, int> summary)
        {

            if (summary.Count == 0)
            {
                Console.WriteLine("Basket is empty");

            }
            else
            {
                Console.WriteLine("Basket contains");
                foreach (var service in summary)
                {
                    Console.WriteLine($"{service.Value} X Service {service.Key}");
                }
            }

        }

    }
}
