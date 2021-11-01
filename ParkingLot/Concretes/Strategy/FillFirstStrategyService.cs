using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.Services
{
    public class FillFirstStrategyService : IParkingStrategyService
    {
        private SortedSet<int> availableParingLotNumbers;
        private Dictionary<int, (Parkinglot parkingLot, SortedSet<int> slotNumber)> parkingLotToSlotsDictionary;

        public FillFirstStrategyService()
        {
            availableParingLotNumbers = new SortedSet<int>();
            parkingLotToSlotsDictionary = new Dictionary<int, (Parkinglot, SortedSet<int>)>();
        }

        public void AddSlot(int parkingLotNumber, int slotNumber)
        {
            parkingLotToSlotsDictionary[parkingLotNumber].slotNumber.Add(slotNumber);
        }

        public int AddNewParkingLot(Parkinglot parkinglot)
        {
            var parkingLotToBeCreated = GetNextParkingLot();
            parkingLotToSlotsDictionary.Add(parkingLotToBeCreated, (parkinglot, new SortedSet<int>()));
            return parkingLotToBeCreated;
        }

        private int GetNextParkingLot()
        {
            return availableParingLotNumbers.Any() ? 1 : availableParingLotNumbers.Max + 1;
        }

        public Parkinglot GetNearestParkingLot() 
        {
            var notFilledParkingLot = parkingLotToSlotsDictionary.First(x => x.Value.parkingLot.IsFilled());
            return notFilledParkingLot.Value.parkingLot;
        }

        public int GetNextAvailableSlot(int parkingLotNmber)
        {
            if (parkingLotToSlotsDictionary[parkingLotNmber].slotNumber.Count == 0)
            {
                throw new NoAvailableSlotException();
            }
            return parkingLotToSlotsDictionary[parkingLotNmber].slotNumber.Min;
        }

        public void RemoveSlot(int parkingLotNmber, int slotNumber)
        {
            parkingLotToSlotsDictionary[parkingLotNmber].slotNumber.Remove(slotNumber);
        }
    }
}
