using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Services;
using System;
using System.Linq;

namespace ParkingLot.Concretes.CommandRunners
{
    public class SlotNoForRegNoCommandRunner : CommandRunner
    {
        public SlotNoForRegNoCommandRunner(ParkingLotService parkingLotService) : base(parkingLotService)
        {

        }
        public override void RunCommand(Command command)
        {
           var occupiedSlots = parkingLotService.GetOccupiedSlots();
            var regNo = command.CommandParams.First();
            var foundCarSlot = occupiedSlots.FirstOrDefault(x => x.ParkedCar.RegistrationNumber == regNo);
            if (foundCarSlot == null)
            {
                Console.WriteLine("No Car with given registration no");
            }
            else 
            {
                Console.WriteLine("Car is at slot no : " + foundCarSlot.SlotNumber);
            }
        }

        public override bool ValidateCommand(Command command)
        {
            return command.CommandParams.Count == 1;
        }
    }
}
