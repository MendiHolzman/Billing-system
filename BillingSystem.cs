using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public delegate void CheckDelegateEventHandler(object sender, ExceptionInformationEventArgs e);



    public class BillingSystem : IEnumerable
    {
        public int _AlertAmount = 10000;
        const int _maximumNumberOfCustomersInTheSystem = 100;
        protected List<Customer> _customers = new List<Customer>(_maximumNumberOfCustomersInTheSystem);
        private int _numOfCustomersInArray = 0;
        private string _Print;
        Random _rnd = new Random();


        public event CheckDelegateEventHandler TheBalanceIsTooHigh;

        public BillingSystem()
        {
            TheBalanceIsTooHigh = new CheckDelegateEventHandler(PrintExceptionalCustomerInformation);
        }

        public void CheckBalance(double UpdatedBalance, Customer customer, double amount)
        {
            if (UpdatedBalance > _AlertAmount)
            {
                OnAmountExceeded(new ExceptionInformationEventArgs(customer, amount));
                customer.resIfbalanceOK = "balanceNotOK";
            }
            else
            {
                customer.resIfbalanceOK = "balanceOK";
            }
        }

        protected virtual void OnAmountExceeded(ExceptionInformationEventArgs e)
        {
            TheBalanceIsTooHigh?.Invoke(this, e);
        }

        public void PrintExceptionalCustomerInformation(object sender, ExceptionInformationEventArgs e)
        {
            Console.WriteLine
               (
                    "Customer balance reached unreasonable limit: 10,000 shekels!"
                  + "\nThe costumer name: " + e._name
                  + "\nThe costumer balance: " + (e._balance + e._amount)
                  + "\n--------------"
               );
        }

        public void ChargingCalls()
        {
            int NumberOfCalls;
            int CallCost;
            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                Customer customer = _customers[i];
                NumberOfCalls = _rnd.Next(5, 40);
                CallCost = _rnd.Next(300, 1000);
                double amount = NumberOfCalls * CallCost;
                double UpdatedBalance = customer._balance + amount;

                CheckBalance(UpdatedBalance, customer, amount);
                customer._balance += amount;
            }
        }

        public void addCustomer(Customer customer)
        {
            if (customer.GetName() == null)
            {
                throw new NullReferenceException();
            }

            if (_numOfCustomersInArray < _maximumNumberOfCustomersInTheSystem)
            {
                _customers.Add(customer);
                _numOfCustomersInArray++;
            }
            else
            {
                throw new IndexOutOfRangeException("You have exceeded the range of adding customers to the system");
            }


        }

        public override string ToString()
        {
            int flag = 0;
            foreach (var Customer in _customers)
            {
                if (flag < _numOfCustomersInArray)
                {
                    _Print += Customer.ToString() + "\n-----------------------------------\n";
                    flag++;
                }
            }
            return _Print;
        }

        public void updateBalance(double amount)
        {
            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                _customers[i].addToBalance(amount, _customers[i]);
            }
        }

        public Customer this[string name]
        {
            get
            {
                return _customers.FirstOrDefault(cus => cus._name == name);
            }
        }

        public Customer this[string name, int id]
        {
            get
            {
                return _customers.FirstOrDefault(cus => cus._name == name && cus._id == id);
            }
        }

        public Customer this[int id]
        {
            get
            {
                return _customers.FirstOrDefault(cus => cus._id == id);
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                Console.WriteLine(_customers[i].ToString());
            }

        }

        public List<Customer> SortByName()
        {
            List<Customer> customers = new List<Customer>(_numOfCustomersInArray);
            string[] names = new string[_numOfCustomersInArray];

            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                customers[i] = _customers[i];
                names[i] = customers[i]._name;
            }

            Array.Sort(names);
            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                customers[i]._name = names[i];
            }
            return customers;
        }

        public List<Customer> SortByCriteria(object criteria)
        {
            Customer[] sortCustomers = new Customer[_numOfCustomersInArray];
            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                sortCustomers[i] = _customers[i];
            }

            if (criteria is CompareCustomersByName)
            {
                Array.Sort(sortCustomers, new CompareCustomersByName());
            }

            else if (criteria is CompreByAge)
            {
                Array.Sort(sortCustomers, new CompreByAge());
            }

            else if (criteria is CompareCustomersBybalans)
            {
                Array.Sort(sortCustomers, new CompareCustomersBybalans());
            }

            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                _customers[i] = sortCustomers[i];
            }

            return _customers;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            int flag = 0;
            foreach (var item in _customers)
            {
                flag++;
                yield return item;
                if (flag == _numOfCustomersInArray)
                {
                    break;
                }
            }
        }

        public List<Customer> DefaultSortCustomers()
        {
            Customer[] customers = new Customer[_numOfCustomersInArray];
            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                customers[i] = _customers[i];
            }
            Array.Sort<Customer>(customers);
            for (int i = 0; i < _numOfCustomersInArray; i++)
            {
                _customers[i] = customers[i];
            }

            return _customers;
        }






    }
}