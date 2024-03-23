using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go_tech_test
{
    public class ServiceData
    {
        public required string serviceName {  get; set; }
        public decimal serviceBasePrice { get; set; }
        public bool hasMultiBuyDiscount {  get; set; }
        public int mutliBuyQuantity { get; set; }
        public decimal multiBuyPrice { get; set; }
    }
}
