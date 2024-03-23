using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go_tech_test
{
    internal interface ICheckout
    {
        bool Scan(string service); // Adds a service to the checkout
        decimal GetTotalPrice(); // Calculates the total price, applying the best discount option
        public Dictionary<string, int> GetBasketSummary();

    }
}
