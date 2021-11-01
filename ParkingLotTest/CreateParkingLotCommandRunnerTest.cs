using NUnit.Framework;
using ParkingLot.Concretes.CommandRunners;
using ParkingLot.Entities;
using ParkingLot.Services;
using System.IO;
using System;

namespace ParkingLotTest
{
    [TestFixture]
    public class CreateParkingLotCommandRunnerTest
    {
        [TestCase("create_parking_lot 6\r\n")]
        public void CreateParkingLotCommandRunner_ValidatePassTest(string input)
        {
            var commandRunner = new CreateParkingLotCommandRunner(new ParkingLotService());

            var command = new Command(input);
            var result = commandRunner.ValidateCommand(command);
            Assert.IsTrue(result);
        }

        [TestCase("create_parking_lot 6 4\r\n")]
        public void CreateParkingLotCommandRunner_ValidateFailTest(string input)
        {
            var commandRunner = new CreateParkingLotCommandRunner(new ParkingLotService());

            var command = new Command(input);
            var result = commandRunner.ValidateCommand(command);
            Assert.IsFalse(result);
        }


        [TestCase("create_parking_lot 6\r\n")]
        public void CreateParkingLotCommandRunner_RunCommandPassTest(string input)
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var commandRunner = new CreateParkingLotCommandRunner(new ParkingLotService());

            var command = new Command(input);
            commandRunner.RunCommand(command);
            Assert.That(output.ToString(), Is.EqualTo("Created a parking lot with 6 slots\r\n"));
        }
    }
}
