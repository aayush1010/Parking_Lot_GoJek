using ParkingLot.Abstracts;
using ParkingLot.Concretes.CommandRunners;
using ParkingLot.Constants;
using ParkingLot.Entities;
using ParkingLot.Exceptions;
using ParkingLot.Services;

namespace ParkingLot.Factory
{
    public class CommandRunnerFactory
    {
        private readonly ParkingLotService parkingLotService;
        public CommandRunnerFactory(ParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }
        public CommandRunner GetCommandRunner(Command command)
        {
            switch (command.CommandName)
            {
                case CommandConstants.CreateParkingLot:
                    return new CreateParkingLotCommandRunner(parkingLotService);
                case CommandConstants.Park:
                    return new ParkCommandRunner(parkingLotService);
                case CommandConstants.Leave:
                    return new LeaveCommandRunner(parkingLotService);
                case CommandConstants.RegNoForCarWithColour:
                    return new RegNoForCarWithColourCommandRunner(parkingLotService);
                case CommandConstants.Status:
                    return new StatusCommandRunner(parkingLotService);
                case CommandConstants.Exit:
                    return new ExitCommandRunner(parkingLotService);
                case CommandConstants.SlotNoForRegNo:
                    return new SlotNoForRegNoCommandRunner(parkingLotService);
                case CommandConstants.SlotNoForColour:
                    return new SlotNumberForColourCommandRunner(parkingLotService);
                default:
                    throw new InvalidCommandException();
            }
        }
    }
}
