using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core
{
    public class Transaction
    {
        // Declaration of the transaction properties.
        public string ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string VehicleType { get; set; }
        public string EmployeeName { get; set; }
        public decimal BaseFee { get; set; }
        public decimal OwnerShare { get; set; }
        public decimal EmployeeShare { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; } // To track employee payment status.
        public string WashStatus { get; set; } // To track the wash status (Ongoing, Completed).
        public decimal DiscountPercentage { get; set; } // To track any discounts applied.
        public decimal ServiceTotal { get; set; }

        // A list to hold the additional services for a transaction.
        public List<Service> AdditionalServices { get; set; }

        public Transaction()
        {
            AdditionalServices = new List<Service>();
        }
    }
}
