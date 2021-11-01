using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.Services
{
    public class ParkingLotService
    {
        private List<Parkinglot> parkingLot;
        private IParkingStrategyService parkingStrategyService;

        public void AssignStretagy(IParkingStrategyService parkingStrategyService) 
        {
            this.parkingStrategyService = parkingStrategyService;
        }

        public void CreateParkingLot(Parkinglot parkingLot)
        {
            this.parkingLot.Add(parkingLot);

            var parkingLotToBeCreated = parkingStrategyService.AddNewParkingLot(parkingLot);
            for (int i = 1; i <= parkingLot.GetCapacity(); i++)
            {
                parkingStrategyService.AddSlot(parkingLotToBeCreated, i);
            }
        }

        public int Park(Car car)
        {
            ValidateParkingLotCreated();
            var availableParkingLot = parkingStrategyService.GetNearestParkingLot();
            var nextAvailableSlot = parkingStrategyService.GetNextAvailableSlot(availableParkingLot.GetId());
            parkingLot.First(x => x.GetId() == availableParkingLot.GetId()).Park(car, nextAvailableSlot);
            parkingStrategyService.RemoveSlot(availableParkingLot.GetId(), nextAvailableSlot);
            return nextAvailableSlot;
        }
        public void MakeSlotAvailable(int parkingLotId, int slotNumber)
        {
            ValidateParkingLotCreated();
            var parkingLotToBeMarked = parkingLot.First(x => x.GetId() == parkingLotId);
            parkingLotToBeMarked.MarkSlotAvailable(slotNumber);
            parkingStrategyService.AddSlot(parkingLotId, slotNumber);
        }

        public List<Slot> GetOccupiedSlots()
        {
            ValidateParkingLotCreated();
            var allSlots = parkingLot.GetAllSlots();
            var occupiedSlotsList = new List<Slot>();

            for (int slot = 1; slot <= parkingLot.GetCapacity(); slot++)
            {
                if (allSlots.ContainsKey(slot) && !allSlots[slot].IsSlotFree())
                {
                    occupiedSlotsList.Add(allSlots[slot]);
                }
            }

            return occupiedSlotsList;
        }

        private void ValidateParkingLotCreated()
        {
            if (parkingLot == null)
            {
                throw new ParkingLotNotCreatedException();
            }
        }

        public List<Slot> GetSlotsForColor(string color)
        {
            var occupiedSlots = GetOccupiedSlots();
            return occupiedSlots.Where(x => x.ParkedCar.Colour == color).ToList();
        }
    }
}
