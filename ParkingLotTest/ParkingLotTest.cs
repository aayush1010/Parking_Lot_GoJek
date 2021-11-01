using NUnit.Framework;
using System.IO;
using System;
using Program = ParkingLot.Program;

namespace ParkingLotTest
{
    [TestFixture]
    public class ParkingLotTest
    {
        private const string invalidCommandInput = 
            "invalid command\r\n"
            +"exit\r\n";
        private const string invalidCommandOotput =
            "Invalid Command\r\n";

        [TestCase(invalidCommandInput)]
        public void InvalidCommandTest(string inputCommand)
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(inputCommand);
            Console.SetIn(input);

            Program.Main(new string[] { });

            Assert.That(output.ToString(), Is.EqualTo(invalidCommandOotput));
        }

        private const string fullIntegrationInput =
        "create_parking_lot 6\r\n"
            + "park UP-37-1010 White\r\n"
            + "park UP-37-3333 White\r\n"
            + "park UP-37-1111 Black\r\n"
            + "park UP-37-2222 Red\r\n"
            + "park UP-37-4444 Blue\r\n"
            + "park UP-37-5555 Black\r\n"
            + "leave 4\r\n"
            + "status\r\n"
            + "park UP-37-9999 White\r\n"
            + "park UP-37-8888 White\r\n"
            + "registration_numbers_for_cars_with_colour Black\r\n"
            + "slot_no_for_reg_no UP-37-1111\r\n"
            + "slot_no_for_colour Blue\r\n"
            + "exit\r\n";

        private const string fullIntegrationOutput =
            "Created a parking lot with 6 slots\r\n"
            + "Allocated slot number: 1\r\n"
            + "Allocated slot number: 2\r\n"
            + "Allocated slot number: 3\r\n"
            + "Allocated slot number: 4\r\n"
            + "Allocated slot number: 5\r\n"
            + "Allocated slot number: 6\r\n"
            + "Slot number 4 is free\r\n"
            + "1    UP-37-1010    White\r\n"
            + "2    UP-37-3333    White\r\n"
            + "3    UP-37-1111    Black\r\n"
            + "5    UP-37-4444    Blue\r\n"
            + "6    UP-37-5555    Black\r\n"
            + "Allocated slot number: 4\r\n"
            + "Sorry, parking lot is full\r\n"
            + "UP-37-1111,UP-37-5555\r\n"
            + "Car is at slot no : 3\r\n"
            + "5\r\n";

        [TestCase(fullIntegrationInput)]
        public void FullIntegrationCommandTest(string inputCommand)
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(inputCommand);
            Console.SetIn(input);

            Program.Main(new string[] { });

            Assert.That(output.ToString(), Is.EqualTo(fullIntegrationOutput));
        }
    }
}
