namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandCentre commandCentre = new CommandCentre();
            Runway runway1 = new Runway();
            Runway runway2 = new Runway();

            commandCentre.AddRunway(runway1);
            commandCentre.AddRunway(runway2);

            Aircraft plane1 = new Aircraft("Plane1");
            Aircraft plane2 = new Aircraft("Plane2");

            commandCentre.AddAircraft(plane1);
            commandCentre.AddAircraft(plane2);

            plane1.SetMediator(commandCentre);
            plane2.SetMediator(commandCentre);

            plane1.Land();
            plane2.Land();
            plane1.TakeOff();
            plane2.TakeOff();
        }
    }
}