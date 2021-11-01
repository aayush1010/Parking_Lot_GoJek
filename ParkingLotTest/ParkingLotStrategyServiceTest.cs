using NUnit.Framework;
using ParkingLot.Services;

namespace ParkingLotTest
{
    [TestFixture]
    public class ParkingLotStrategyServiceTest
    {
        [TestCase]
        public void GetNextAvailableSlot_PassTest() 
        {
            var parkingStrategyService = new FillFirstStrategyService();
            parkingStrategyService.AddSlot(1);
            parkingStrategyService.AddSlot(2);
            int nextAvailableSlot = parkingStrategyService.GetNextAvailableSlot();
            Assert.AreEqual(1, nextAvailableSlot);
        }

        [TestCase]
        public void GetNextAvailableSlotAfterRemoving_PassTest()
        {
            var parkingStrategyService = new FillFirstStrategyService();
            parkingStrategyService.AddSlot(1);
            parkingStrategyService.AddSlot(2);
            parkingStrategyService.RemoveSlot(1);
            int nextAvailableSlot = parkingStrategyService.GetNextAvailableSlot();
            Assert.AreEqual(2, nextAvailableSlot);
        }
    }
}
