using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Services;
using System.Linq;

namespace ParkingLot.Concretes.CommandRunners
{
    public class ExitCommandRunner : CommandRunner
    {
        public ExitCommandRunner(ParkingLotService parkingLotService) : base(parkingLotService)
        {
        }

        public override void RunCommand(Command command)
        {
        }

        public override bool ValidateCommand(Command command)
        {
            return !command.CommandParams.Any();
        }
    }
}
