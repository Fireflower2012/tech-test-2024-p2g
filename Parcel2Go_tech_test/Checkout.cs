using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go_tech_test
{
    public class Checkout : ICheckout
    {
        public List<String> ShoppingBasket { get; set; }
        public IServiceCatalogue _serviceCatalogue { get; set; }


      public  Checkout(IServiceCatalogue catalogue)
        {
            _serviceCatalogue = catalogue;
            ShoppingBasket = new List<String>();
        }
        public bool Scan(string service)
        {
            string enteredService = service.Trim().ToUpper();

            var serviceData = _serviceCatalogue.getCatalogue().FirstOrDefault(s => s.serviceName == enteredService);

            if (serviceData == null)
            {
                return false;
            }
            else
            {
                ShoppingBasket.Add(enteredService);
                return true;
            }

        }

      public decimal GetTotalPrice()
        {

            decimal totalPrice = 0;

            foreach (var service in GetBasketSummary())
            {
                totalPrice = totalPrice + CalculatePricePerService(service.Key, service.Value);
            }

            return totalPrice;
        }


        public Dictionary<string, int> GetBasketSummary()
        {
            Dictionary<string, int> summary = new Dictionary<string, int>();

            var servicesAdded = ShoppingBasket.Distinct().ToList();

            foreach (var service in servicesAdded)
            {
                summary.Add(service, ShoppingBasket.Where<String>(i => i == service).Count());
            }

            return summary;
        }


        private decimal CalculatePricePerService(string service, int quantity)
        {
            decimal totalCost = 0;
            var serviceData = _serviceCatalogue.getCatalogue().FirstOrDefault(s => s.serviceName == service);

            if (serviceData != null)
            {
                if (serviceData.hasMultiBuyDiscount)
                {
                    int quantityForMutlibuy = quantity / serviceData.mutliBuyQuantity;
                    int quantityForSingle = quantity % serviceData.mutliBuyQuantity;

                    totalCost = (quantityForMutlibuy * serviceData.multiBuyPrice) + (quantityForSingle * serviceData.serviceBasePrice);
                }
                else
                {
                    totalCost = quantity * serviceData.serviceBasePrice;
                }
            }
          

            return totalCost;
        }


    }
}
