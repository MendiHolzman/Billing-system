using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    class CompreByAge : IComparer<Customer>
    {
        public int Compare(Customer cus1, Customer cus2)
        {
            return cus1._age.CompareTo(cus2._age);
        }
    }
}
