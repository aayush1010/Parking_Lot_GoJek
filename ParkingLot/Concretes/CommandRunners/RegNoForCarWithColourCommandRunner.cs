using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Services;
using System;
using System.Linq;

namespace ParkingLot.Concretes.CommandRunners
{
    public class RegNoForCarWithColourCommandRunner : CommandRunner
    {
        public RegNoForCarWithColourCommandRunner(ParkingLotService parkingLotService) : base(parkingLotService)
        {
        }

        public override void RunCommand(Command command)
        {
            var colour = command.CommandParams[0];
            var carSlots = parkingLotService.GetSlotsForColor(colour);
            if (carSlots.Any())
            {
                Console.WriteLine(string.Join(Constants.Constants.Seperator, carSlots.Select(x => x.ParkedCar.RegistrationNumber)));
            }
            else
            {
                Console.WriteLine("No Car with " + colour + " colour");
            }
        }

        public override bool ValidateCommand(Command command)
        {
            return command.CommandParams.Count == 1;
        }
    }
}
