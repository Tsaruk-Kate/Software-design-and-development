using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class CommandCentre : ICommandCentreMediator
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();

        public void AddRunway(Runway runway)
        {
            _runways.Add(runway);
        }

        public void AddAircraft(Aircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }

        public bool CheckRunwayStatus()
        {
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft != null && runway.IsBusyWithAircraft.IsTakingOff)
                    return true;
            }
            return false;
        }

        public void LandAircraft(Aircraft aircraft)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is landing.");
            Console.WriteLine($"Checking runways.");
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft == null)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} has landed on runway {runway.Id}.");
                    runway.IsBusyWithAircraft = aircraft;
                    return;
                }
            }
            Console.WriteLine($"Could not land, all runways are busy.");
        }

        public void TakeOffAircraft(Aircraft aircraft)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is taking off.");
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft == aircraft)
                {
                    runway.IsBusyWithAircraft = null;
                    Console.WriteLine($"Aircraft {aircraft.Name} has taken off from runway {runway.Id}.");
                    return;
                }
            }
            Console.WriteLine($"Could not take off, aircraft not found on any runway.");
        }
    }
}