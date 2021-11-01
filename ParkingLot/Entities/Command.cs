using ParkingLot.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.Entities
{
    public class Command
    {
        private string commandName;
        private List<string> commandParams;
        public Command(string inputCommand)
        {
            if (string.IsNullOrWhiteSpace(inputCommand))
            {
                throw new InvalidCommandException();
            }
            var commandList = inputCommand.Split(Constants.Constants.CommandSpliter).ToList();
            commandName = commandList[0];
            commandList.RemoveAt(0);
            commandParams = commandList;
        }

        public string CommandName
        {
            get { return commandName; }
        }

        public List<string> CommandParams 
        {
            get { return commandParams; }
        }
    }
}
