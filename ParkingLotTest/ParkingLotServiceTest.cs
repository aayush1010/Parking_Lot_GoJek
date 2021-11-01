using NUnit.Framework;
using ParkingLot.Entities;
using ParkingLot.Exceptions;
using ParkingLot.Services;

namespace ParkingLotTest
{
    [TestFixture]
    public class ParkingLotServiceTest
    {
        [TestCase]
        public void ParkCar_PassTest() 
        {
            var parkingLotService = new ParkingLotService();
            parkingLotService.CreateParkingLot(new Parkinglot(2), new FillFirstStrategyService());
            var carSlot = parkingLotService.Park(new Car("abcd-123", "Black"));
            Assert.AreEqual(1, carSlot);
        }

        [TestCase]
        public void ParkCar_FullParkingLotTest()
        {
            var parkingLotService = new ParkingLotService();
            parkingLotService.CreateParkingLot(new Parkinglot(2), new FillFirstStrategyService());
            var carSlot1 = parkingLotService.Park(new Car("abcd-123", "Black"));
            var carSlot2 = parkingLotService.Park(new Car("abcd-456", "Black"));
            Assert.That(() => parkingLotService.Park(new Car("abcd-789", "Black")), Throws.TypeOf<NoAvailableSlotException>());
        }

        [TestCase]
        public void ParkCar_GetOccupiedSlotsTest()
        {
            var parkingLotService = new ParkingLotService();
            parkingLotService.CreateParkingLot(new Parkinglot(2), new FillFirstStrategyService());
            var carSlot1 = parkingLotService.Park(new Car("abcd-123", "Black"));
            var carSlot2 = parkingLotService.Park(new Car("abcd-456", "Black"));
            var getOccupiedSlots = parkingLotService.GetOccupiedSlots();
            Assert.AreEqual(2, getOccupiedSlots.Count);
            //Assert.AreEqual(carSlot1, getOccupiedSlots[0]);
            //Assert.AreEqual(carSlot2, getOccupiedSlots[1]);
        }
    }
}
