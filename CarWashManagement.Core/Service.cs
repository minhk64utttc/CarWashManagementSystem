using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManagement.Core.Enums;

namespace CarWashManagement.Core
{
    public class Service
    {
        // Declaration of the transaction properties.
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public ServicePricingType PricingType { get; set; }

        // This is used if the PricingType is VehicleBaseFeeMultiplier.
        public int Multiplier { get; set; }

        // Default constructor.
        public Service() { }

        // Constructor with parameters.
        public Service(string name, decimal fee, ServicePricingType pricingType, int multiplier = 1)
        {
            Name = name;
            Fee = fee;
            PricingType = pricingType;
            Multiplier = multiplier;
        }
    }
}
