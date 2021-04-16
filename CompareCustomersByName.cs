using System.Collections;
using System.Collections.Generic;

namespace BillingSystem
{
    public class CompareCustomersByName : IComparer<Customer>
    {
        public int Compare(Customer cus1, Customer cus2)
        {
            return cus1._name.CompareTo(cus2._name);
        }
    }
}
