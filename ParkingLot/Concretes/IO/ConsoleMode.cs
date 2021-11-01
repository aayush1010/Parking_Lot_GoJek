using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Factory;
using System;

namespace ParkingLot.Concretes.IO
{
    public class ConsoleMode : IOMode
    {
        public ConsoleMode(CommandRunnerFactory commandRunnerFactory) : base(commandRunnerFactory)
        {
        }
        public override void ProcessAndRun()
        {
            while (true)
            {

                var commandInput = Console.ReadLine();
                var command = new Command(commandInput);
                RunCommand(command);
                if (command.CommandName == Constants.CommandConstants.Exit)
                {
                    break;
                }
            }
        }
    }
}
