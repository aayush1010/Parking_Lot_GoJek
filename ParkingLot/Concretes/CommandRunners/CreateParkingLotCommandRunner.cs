using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Helpers;
using ParkingLot.Services;
using System;
using System.Linq;

namespace ParkingLot.Concretes.CommandRunners
{
    public class CreateParkingLotCommandRunner : CommandRunner
    {
        public CreateParkingLotCommandRunner(ParkingLotService parkingLotService) : base(parkingLotService)
        {
        }

        public override void RunCommand(Command command)
        {
            int capacity = int.Parse(command.CommandParams.First());
            var parkingLot = new Parkinglot(capacity);  
            parkingLotService.CreateParkingLot(parkingLot, new FillFirstStrategyService());
            Console.WriteLine("Created a parking lot with " + capacity + " slots");
        }

        public override bool ValidateCommand(Command command)
        {
            var parameters = command.CommandParams;
            return parameters.Count == 1 && IntegerHelper.IsInteger(parameters[0]);
        }
    }
}
