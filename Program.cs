using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    class Program
    {      
        static void Main(string[] args)
        {        
            try
            {
                //Create BillingSystem
                BillingSystem billing1 = new BillingSystem();

                //Create Criteria
                //CompareCustomersBybalans bybalance = new CompareCustomersBybalans();
                //CompareCustomersByName byName = new CompareCustomersByName();
                //CompreByAge byage = new CompreByAge();

                //Create customers
                RegularCustomer regular1 = new RegularCustomer("shalom", 2000, 204);
                VIPCustomer vip1 = new VIPCustomer("david", 10001, 42);
                RegularCustomer regular2 = new RegularCustomer("mendel", 2000, 33);
                VIPCustomer vip2 = new VIPCustomer("dina", 2000, 44);
                VIPCustomer vip3 = new VIPCustomer("dan", 2000, 333);
              
                //addCustomers
                billing1.addCustomer(regular1);
                billing1.addCustomer(vip1);
                billing1.addCustomer(regular2);
                billing1.addCustomer(vip2);
                billing1.addCustomer(vip3);

                //Create Customer Service
                CustomerService service1 = new CustomerService(billing1);

                //Create Accounting Clerk
                AccountingClerk clerk1 = new AccountingClerk(billing1);

                //Call to call charges function
                billing1.ChargingCalls();



                //addToBalance
                //vip1.addToBalance(10001, vip1);
                //regular2.addToBalance(8001, regular2);

                //update
                //billing1.updateBalance(8001);

                //DefaultSort              
                //billing1.DefaultSortCustomers();

                //PrintAllCustomersInBillingSystem
                billing1.PrintAll();

                //SortByCriteria
                //Console.WriteLine("\nbefore\n");
                //billing1.PrintAll();
                //Console.WriteLine("\nafter\n");
                //billing1.SortByCriteria(bybalance);
                //billing1.PrintAll();

                //Iterator            
                //Console.WriteLine("\n In Iterator \n");
                //foreach (var item in billing1)
                //{
                //    Console.WriteLine(item + " ");
                //}

            }

            #region Mycatch1
            catch (NullReferenceException e1)
            {

                throw new ArgumentNullException ("\n\n\nAdd a client to a system with an invalid name (nal, no, etc.),\n" 
                  +"please change to a valid name (regular string - first name),\n"
                    + "and restart the program.\n\n\n\n" , e1);

            }
            #endregion

            #region Mycatch2
            catch (IndexOutOfRangeException e2)
            {

                throw new IndexOutOfRangeException("\n\n\nYou have reached the maximum size of customers in the system, \n" +
                    "the system is currently usable up to 100 customers and you have tried to add the 101 client, \n" +
                    "in the next version the system will be expanded, with you forgiveness.\n\n\n\n", e2);

            }
            #endregion

        }                  
    }
}
