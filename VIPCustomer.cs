using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
   public class VIPCustomer:Customer
    {
        public VIPCustomer(string name) : base(name)
        {
            
        }

        public VIPCustomer(string name, double balance, int age):base(name ,balance, age)
        {
           
        }

        public override void addToBalance(double amount, Customer customer)
        {
            BillingSystem billingSystem = new BillingSystem();
            billingSystem.CheckBalance((amount - amount / 5) + _balance, customer, amount);
            _balance += amount - amount / 5;
        }

        public override string ToString()
        {
                return "name: " 
                + _name.ToString() 
                + "\nbalance: "
                + _balance.ToString() 
                + "\nid: "
                + _id.ToString()
                + "\nage: " 
                + _age.ToString() 
                +  "\nI am a VIP customer "
                + "\n----------------------";
        }


    }
}
