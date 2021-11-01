using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Helpers;
using ParkingLot.Services;
using System;

namespace ParkingLot.Concretes.CommandRunners
{
    public class LeaveCommandRunner : CommandRunner
    {
        public LeaveCommandRunner(ParkingLotService parkingLotService) :base(parkingLotService)
        {
        }

        public override void RunCommand(Command command)
        {
            var slotNum = int.Parse(command.CommandParams[0]);
            parkingLotService.MakeSlotAvailable(slotNum);
            Console.WriteLine("Slot number " + slotNum + " is free");
        }

        public override bool ValidateCommand(Command command)
        {
            var parameters = command.CommandParams;
            return parameters.Count == 1 && IntegerHelper.IsInteger(parameters[0]);
        }
    }
}
