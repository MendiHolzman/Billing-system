using System;

namespace BillingSystem
{
    public class AccountingClerk
    {
        private BillingSystem _billing;
        public AccountingClerk(BillingSystem billing)
        {
            _billing = billing;
            _billing.TheBalanceIsTooHigh += PrintAMessage;
        }

        public void PrintAMessage(object sender, ExceptionInformationEventArgs e)
        {
            Console.WriteLine
                (
                "I am Accounting Clerk and I'm going to report" +
                " to the CFO the details" +
                " Of the client who exceeded!\n"
                );
        }
    }
}
