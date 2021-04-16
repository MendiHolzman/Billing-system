using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    
    [DebuggerDisplay("name = {_name}, indication Balance={resIfbalanceOK}")]
    public abstract class Customer: IComparable<Customer>
    {
        public int _age;
        public string _name;
        public double _balance = 0;
        public int _id = 0;
        private static int following = 0;
        public string resIfbalanceOK="";
        

        public Customer(string name)
        {
            _name = name;
            following++;
            AddOneToId();
        }

        public Customer(string name, double balance, int age)
        {
            _name = name;
            following++;
            AddOneToId();
            _balance = balance;
            _age = age;
        }

        public void AddOneToId()
        {
            _id = following;
        }

        public override string ToString()
        {
            return "name: " + _name.ToString() + "\nbalance: "
                + _balance.ToString() + "\nid: " + _id.ToString() +
                 "\nage: " + _age.ToString() +
                 "\n----------------------";
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public double Getbalance()
        {
            return _balance;
        }

        public void Setbalance(double balance)
        {
            _balance = balance;
        }

        public int GetId()
        {
            return _id;
        }

        public static void PrintCustomer(Customer customer)
        {
            Console.WriteLine(customer.ToString());
        }

        public virtual void addToBalance(double amount, Customer customer)
        {

        }

        public int CompareTo(Customer other)
        {
            return this._balance.CompareTo(other._balance);             
        }
    }
}
