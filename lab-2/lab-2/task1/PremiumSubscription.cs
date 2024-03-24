using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription() : base(29.99m, 12, new List<string> { "Premium", "Sports", "Movies", "Entertainment" }) { }

        public override void DisplayDetails()
        {
            Console.WriteLine("Premium Subscription Details:");
            Console.WriteLine($"Monthly Fee: {MonthlyFee}");
            Console.WriteLine($"Minimum Subscription Period: {MinimumSubscriptionPeriod} month(s)");
            Console.WriteLine($"Included Channels: {string.Join(", ", IncludedChannels)}");
        }
    }
}
