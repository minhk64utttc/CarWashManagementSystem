using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core.Enums
{
    public enum ServicePricingType
    {
        FixedPrice,                 // Price is set by the Fee field of the Service.
        ManualInput,                // Price is manually inputted during transaction.
        VehicleBaseFeeMultiplier    // Price is calculated as Vehicle.BaseFee * Multiplier.
    }
}
