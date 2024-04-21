using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public Aircraft? IsBusyWithAircraft;
    }
}