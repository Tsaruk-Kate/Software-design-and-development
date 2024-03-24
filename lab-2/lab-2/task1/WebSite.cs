using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class WebSite : PurchaseMethod
    {
        public override void Purchase(Subscription subscription)
        {
            Console.WriteLine($"Purchasing subscription through WebSite for the following subscription:");
            subscription.DisplayDetails();
            Console.WriteLine("Please enter the subscription fee:");
            decimal enteredAmount = Convert.ToDecimal(Console.ReadLine());

            if (enteredAmount != subscription.MonthlyFee)
            {
                Console.WriteLine("Error: Entered amount doesn't match subscription fee.");
                return;
            }

            Console.WriteLine("Please enter your payment details (credit card number, expiry date, etc.):");
            string creditCardNumber = Console.ReadLine();
            string expiryDate = Console.ReadLine();

            Console.WriteLine("Payment confirmed! Subscription purchased successfully via WebSite.");
        }
    }
}
