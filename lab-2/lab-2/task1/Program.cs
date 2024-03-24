using System;
using System.Collections.Generic;
using task1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Subscription Service!");
        Console.WriteLine("Please choose the type of subscription:");
        Console.WriteLine("1. Domestic Subscription");
        Console.WriteLine("2. Educational Subscription");
        Console.WriteLine("3. Premium Subscription");

        int subscriptionTypeChoice = Convert.ToInt32(Console.ReadLine());

        Subscription subscription = null;
        switch (subscriptionTypeChoice)
        {
            case 1:
                subscription = SubscriptionFactory.CreateSubscription("domestic");
                break;
            case 2:
                subscription = SubscriptionFactory.CreateSubscription("educational");
                break;
            case 3:
                subscription = SubscriptionFactory.CreateSubscription("premium");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }

        Console.WriteLine("Please choose the method of purchase:");
        Console.WriteLine("1. WebSite");
        Console.WriteLine("2. MobileApp");
        Console.WriteLine("3. ManagerCall");
        int purchaseMethodChoice = Convert.ToInt32(Console.ReadLine());

        PurchaseMethod purchaseMethod = null;
        switch (purchaseMethodChoice)
        {
            case 1:
                purchaseMethod = new WebSite();
                break;
            case 2:
                purchaseMethod = new MobileApp();
                break;
            case 3:
                purchaseMethod = new ManagerCall();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }

        purchaseMethod.Purchase(subscription);
    }
}