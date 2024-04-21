using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    interface ICommandCentreMediator
    {
        void LandAircraft(Aircraft aircraft);
        void TakeOffAircraft(Aircraft aircraft);
        bool CheckRunwayStatus();
    }
}