using System;

namespace BillingSystem
{
    public class CustomerService
    {
        BillingSystem _billing;
        public CustomerService(BillingSystem billing)
        {
            _billing = billing;
            _billing.TheBalanceIsTooHigh += PrintAMessage;
        }
       
        public void PrintAMessage(object sender, ExceptionInformationEventArgs e)
        {
            Console.WriteLine
                (
                "I am Customer Service and I'm going to call the customer" +
                " to make sure his phone line" +
                " is not being misused.\n"
                );
        }
    }
}
