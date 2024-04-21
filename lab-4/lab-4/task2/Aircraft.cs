using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Aircraft
    {
        private ICommandCentreMediator _mediator;

        public string Name;
        public bool IsTakingOff { get; set; }

        public Aircraft(string name)
        {
            Name = name;
        }

        public void SetMediator(ICommandCentreMediator mediator)
        {
            _mediator = mediator;
        }

        public void Land()
        {
            _mediator.LandAircraft(this);
        }

        public void TakeOff()
        {
            _mediator.TakeOffAircraft(this);
        }
    }
}