using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go_tech_test
{
    public class ServiceCatalogue: IServiceCatalogue
    {
        public List<ServiceData> ServiceCatalogueList;
        public ServiceCatalogue() {

            ServiceCatalogueList = new List<ServiceData>();
            PopulateServiceCatalogueData();
        }
    
        public List<ServiceData> getCatalogue()
        {
            return ServiceCatalogueList;
        }


        private void PopulateServiceCatalogueData()
        {
            ServiceCatalogueList.Add(new ServiceData()
            {
                serviceName = "A",
                serviceBasePrice = 10.0m,
                hasMultiBuyDiscount = true,
                mutliBuyQuantity = 3,
                multiBuyPrice = 25.0m
            });

            ServiceCatalogueList.Add(new ServiceData()
            {
                serviceName = "B",
                serviceBasePrice = 12.0m,
                hasMultiBuyDiscount = true,
                mutliBuyQuantity = 2,
                multiBuyPrice = 20.0m
            });

            ServiceCatalogueList.Add(new ServiceData()
            {
                serviceName = "C",
                serviceBasePrice = 15.0m,
                hasMultiBuyDiscount = false,
                mutliBuyQuantity = 0,
                multiBuyPrice = 0
            });

            ServiceCatalogueList.Add(new ServiceData()
            {
                serviceName = "D",
                serviceBasePrice = 25.0m,
                hasMultiBuyDiscount = false,
                mutliBuyQuantity = 0,
                multiBuyPrice = 0
            });

            ServiceCatalogueList.Add(new ServiceData()
            {
                serviceName = "F",
                serviceBasePrice = 8.0m,
                hasMultiBuyDiscount = true,
                mutliBuyQuantity = 2,
                multiBuyPrice = 15.0m
            });

        }

    }
}
