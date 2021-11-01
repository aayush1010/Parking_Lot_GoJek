using ParkingLot.Entities;
using ParkingLot.Exceptions;
using ParkingLot.Factory;
using System;

namespace ParkingLot.Abstracts
{
    public abstract class IOMode
    {
        private readonly CommandRunnerFactory commandRunnerFactory;

        public IOMode(CommandRunnerFactory commandRunnerFactory)
        {
            this.commandRunnerFactory = commandRunnerFactory;
        }

        public abstract void ProcessAndRun();

        public void RunCommand(Command command)
        {
            try
            {
                var commandRunner = commandRunnerFactory.GetCommandRunner(command);
                if (commandRunner.ValidateCommand(command))
                {
                    commandRunner.RunCommand(command);
                }
                else
                {
                    throw new InvalidCommandException();
                }
            }
            catch (NoAvailableSlotException ex)
            {
                Console.WriteLine("Sorry, parking lot is full");
            }
            catch (InvalidCommandException ex)
            {
                Console.WriteLine("Invalid Command");
            }
            catch (ParkingLotNotCreatedException ex) 
            {
                Console.WriteLine("Parking Lot not created");
            }
        }
    }
}
