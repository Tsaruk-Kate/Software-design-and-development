using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class ManagerCall : PurchaseMethod
    {
        public override void Purchase(Subscription subscription)
        {
            Console.WriteLine($"Purchasing subscription through ManagerCall for the following subscription:");
            subscription.DisplayDetails();
            Console.WriteLine("Please enter the subscription fee:");
            decimal enteredAmount = Convert.ToDecimal(Console.ReadLine());

            if (enteredAmount != subscription.MonthlyFee)
            {
                Console.WriteLine("Error: Entered amount doesn't match subscription fee.");
                return;
            }

            Console.WriteLine("Please provide your details to the manager for purchase (name, address, payment method, etc.):");

            string name = Console.ReadLine();
            string address = Console.ReadLine();
            string paymentMethod = Console.ReadLine();


            Console.WriteLine("Payment confirmed! Subscription purchased successfully via ManagerCall.");
        }
    }
}
