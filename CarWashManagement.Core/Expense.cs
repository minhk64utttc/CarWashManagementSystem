using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core
{
    public class Expense
    {
        // Declaration of the expense properties.
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Expense()
        {
            Id = Guid.NewGuid();
        }
    }
}
