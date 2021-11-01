namespace ParkingLot.Entities
{
    public class Slot
    {
        private Car parkedCar;
        private int slotNumber;

        public Slot(int slotNumber)
        {
            this.slotNumber = slotNumber;
        }

        public int SlotNumber
        {
            get { return slotNumber; }  
        }

        public Car ParkedCar
        {
            get { return parkedCar; }
        }

        public bool IsSlotFree()
        {
            return parkedCar == null;
        }

        public void AssignCar(Car car)
        {
            this.parkedCar = car;
        }

        public void UnassignCar()
        {
            this.parkedCar = null;
        }
    }
}
