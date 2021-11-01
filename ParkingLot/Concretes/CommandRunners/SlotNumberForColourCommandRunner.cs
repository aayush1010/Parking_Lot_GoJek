using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Services;
using System;
using System.Linq;

namespace ParkingLot.Concretes.CommandRunners
{
    public class SlotNumberForColourCommandRunner : CommandRunner
    {
        public SlotNumberForColourCommandRunner(ParkingLotService parkinglotService) : base(parkinglotService)
        {
        }

        public override void RunCommand(Command command)
        {
            var colour = command.CommandParams.First();
            var slotsOccupiedForColour = parkingLotService.GetSlotsForColor(colour);
            if (slotsOccupiedForColour.Any())
            {
                Console.WriteLine(string.Join(Constants.Constants.Seperator, slotsOccupiedForColour.Select(x => x.SlotNumber)));
            }
            else
            {
                Console.WriteLine("No Slot Found");
            }
        }

        public override bool ValidateCommand(Command command)
        {
            return command.CommandParams.Count == 1;
        }
    }
}
