using ParkingLot.Abstracts;
using ParkingLot.Concretes.IO;
using ParkingLot.Factory;
using ParkingLot.Services;
using System.Linq;

namespace ParkingLot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parkingLotService = new ParkingLotService();
            var commandRunnerFactory = new CommandRunnerFactory(parkingLotService);
            IOMode mode;
            if (args == null || args.Length == 0)
            {
                mode =new ConsoleMode(commandRunnerFactory);
            }
            else
            {
                mode = new FileMode(commandRunnerFactory, args.First());
            }
            mode.ProcessAndRun();
        }
    }
}
