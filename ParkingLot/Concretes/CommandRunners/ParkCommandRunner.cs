using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Services;
using System;

namespace ParkingLot.Concretes.CommandRunners
{
    public class ParkCommandRunner : CommandRunner
    {
        public ParkCommandRunner(ParkingLotService parkingLotService) : base(parkingLotService)
        {
        }
        public override void RunCommand(Command command)
        {
            var regNo = command.CommandParams[0];
            var colour = command.CommandParams[1];
            var car = new Car(regNo, colour);
            var slot = parkingLotService.Park(car);
            Console.WriteLine("Allocated slot number: " +  slot);
        }

        public override bool ValidateCommand(Command command)
        {
            return command.CommandParams.Count == 2;
        }
    }
}
