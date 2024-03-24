using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription() : base(19.99m, 6, new List<string> { "Educational", "Documentary", "General" }) { }

        public override void DisplayDetails()
        {
            Console.WriteLine("Educational Subscription Details:");
            Console.WriteLine($"Monthly Fee: {MonthlyFee}");
            Console.WriteLine($"Minimum Subscription Period: {MinimumSubscriptionPeriod} month(s)");
            Console.WriteLine($"Included Channels: {string.Join(", ", IncludedChannels)}");
        }
    }
}
