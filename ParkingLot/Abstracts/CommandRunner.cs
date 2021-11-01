using ParkingLot.Entities;
using ParkingLot.Services;

namespace ParkingLot.Abstracts
{
    public abstract class CommandRunner
    {
        protected readonly ParkingLotService parkingLotService;

        public CommandRunner(ParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }

        public abstract bool ValidateCommand(Command command);

        public abstract void RunCommand(Command command);
    }
}
