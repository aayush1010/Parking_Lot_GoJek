using Moq;
using NUnit.Framework;
using ParkingLot.Concretes.CommandRunners;
using ParkingLot.Entities;
using ParkingLot.Exceptions;
using ParkingLot.Factory;
using ParkingLot.Services;

namespace ParkingLotTest
{
    [TestFixture]
    public class CommandRunnerFactoryTest
    {
        private Mock<ParkingLotService> mockParkingLotService;

        [OneTimeSetUp]
        public void Initialize() 
        {
            mockParkingLotService = new Mock<ParkingLotService>();
        }

        [TestCase("create_parking_lot 6")]
        public void CreateParkingLotCommandRunnerObjectTest(string input)
        {
            var commandRunner = new CommandRunnerFactory(mockParkingLotService.Object);

            var command = new Command(input);

            var createdPlObj = commandRunner.GetCommandRunner(command);

            Assert.That(createdPlObj, Is.TypeOf<CreateParkingLotCommandRunner>());
        }

        [TestCase("invalid 6")]
        public void InvalidCommandRunnerTest(string input)
        {
            var commandRunner = new CommandRunnerFactory(mockParkingLotService.Object);

            var command = new Command(input);

            Assert.That(() => commandRunner.GetCommandRunner(command), Throws.TypeOf<InvalidCommandException>());
        }
    }
}
