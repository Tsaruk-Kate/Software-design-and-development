using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription() : base(10.99m, 1, new List<string> { "General", "News", "Entertainment" }) { }

        public override void DisplayDetails()
        {
            Console.WriteLine("Domestic Subscription Details:");
            Console.WriteLine($"Monthly Fee: {MonthlyFee}");
            Console.WriteLine($"Minimum Subscription Period: {MinimumSubscriptionPeriod} month(s)");
            Console.WriteLine($"Included Channels: {string.Join(", ", IncludedChannels)}");
        }
    }
}
