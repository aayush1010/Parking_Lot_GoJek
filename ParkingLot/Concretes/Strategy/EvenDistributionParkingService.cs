using ParkingLot.Abstracts;
using ParkingLot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Concretes.Strategy
{
    public class EvenDistributionParkingService : IParkingStrategyService
    {
       
        public Parkinglot GetNearestParkingLot()
        {
            var minimumFilledParkingLot = parkingLotToSlotsDictionary.Min(x => x.Value.parkingLot.PercentageFilled);
            return parkingLotToSlotsDictionary[minimumFilledParkingLot].parkingLot;
        }

    }
}
