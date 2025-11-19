using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core
{
    public class Vehicle
    {
        // Declaration of the vehicle properties.
        public string Type { get; set; }
        public decimal BaseFee { get; set; }
        public decimal OwnerShare {  get; set; }
        public decimal EmployeeShare { get; set; }

        // Default constructor.
        public Vehicle() { }

        // Constructor with parameters.
        public Vehicle(string type, decimal baseFee, decimal ownerShare, decimal employeeShare)
        {
            Type = type;
            BaseFee = baseFee;
            OwnerShare = ownerShare;
            EmployeeShare = employeeShare;
        }
    }
}
