using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class ExceptionInformationEventArgs : EventArgs
    {
        public string _name { get; set; }
        public double _balance { get; set; }
        public double _amount { get; set; }

        public ExceptionInformationEventArgs(Customer customer, double amount)
        {
            _name = customer._name;
            _balance = customer._balance;
            
            if (customer is RegularCustomer)
            {
                _amount = amount;
            }
            else if (customer is VIPCustomer)
            {
                _amount = amount - (amount / 5);
            }
        }
       

    }
}
