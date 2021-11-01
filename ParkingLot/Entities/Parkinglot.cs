using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.Entities
{
    public class Parkinglot
    {
        private readonly int capacity;
        private readonly int id;
        private Dictionary<int, Slot> slots;

        public Parkinglot(int capacity, int id)
        {
            this.id = id;
            this.capacity = capacity;
            this.slots = new Dictionary<int, Slot>();
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public int GetId()
        {
            return id;
        }

        public Dictionary<int, Slot> GetAllSlots()
        {
            return slots;
        }

        public Slot Park(Car car, int slotNumber)
        {
            var slot = GetSlot(slotNumber);
            slot.AssignCar(car);
            return slot;
        }

        public int PercentageFilled 
        {
            get { return 0; }
            // returnthe PercentageFilled
        }

        public Slot MarkSlotAvailable(int slotNumber)
        {
            var slot = GetSlot(slotNumber);
            slot.UnassignCar();
            return slot;
        }

        public bool IsFilled()
        {
            return slots.Where(x => x.Value.IsSlotFree()).Count() == capacity;
        }

        private Slot GetSlot(int slotNumber)
        {
            var allSlots = GetAllSlots();
            if (!allSlots.ContainsKey(slotNumber))
            {
                allSlots.Add(slotNumber, new Slot(slotNumber));
            }
            return allSlots[slotNumber];
        }
    }
}
