using ParkingLot.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Abstracts
{
    public abstract class IParkingStrategyService
    {
     private SortedSet<int> availableParingLotNumbers;
    private Dictionary<int, (Parkinglot parkingLot, SortedSet<int> slotNumber)> parkingLotToSlotsDictionary;
}
}
