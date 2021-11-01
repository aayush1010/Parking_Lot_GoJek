using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Factory;
using System.IO;

namespace ParkingLot.Concretes.IO
{
    public class FileMode : IOMode
    {
        private readonly string fileName;
        public FileMode(CommandRunnerFactory commandRunnerFactory, string fileName) : base(commandRunnerFactory)
        {
            this.fileName = fileName;
        }

        public override void ProcessAndRun()
        {
            string line;

            using (StreamReader file = new StreamReader(fileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var command = new Command(line);
                    RunCommand(command);
                    if (command.CommandName == Constants.CommandConstants.Exit)
                    {
                        break;
                    }
                }
            }
        }
    }
}
