using ParkingLot.Abstracts;
using ParkingLot.Concretes.Strategy;
using ParkingLot.Entities;
using ParkingLot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Concretes.CommandRunners
{
    public class DispatchRuleCommandRunner : CommandRunner
    {
        public DispatchRuleCommandRunner(ParkingLotService parkingLotService) : base(parkingLotService)
        {
        }

        public override void RunCommand(Command command)
        {
            IParkingStrategyService parkingStrategy;
            if (command.CommandParams.First() == "even_distribution") 
            {
                parkingStrategy = new EvenDistributionParkingService();
            }
            else 
            {
                parkingStrategy = new FillFirstStrategyService();
            }
            parkingLotService.AssignStretagy(parkingStrategy);
        }

        public override bool ValidateCommand(Command command)
        {
           return command.CommandParams.Count == 1;
        }
    }
}
