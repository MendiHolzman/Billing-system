using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
  public  class RegularCustomer:Customer
    {

        public RegularCustomer(string name) : base(name)
        {
            
        }

        public RegularCustomer(string name, double balance, int age) : base(name, balance, age)
        {
            
        }

        public override void addToBalance(double amount, Customer customer)
        {
            BillingSystem billingSystem = new BillingSystem();
            billingSystem.CheckBalance(amount+_balance, customer, amount);
            _balance += amount;
        }

    }
}
