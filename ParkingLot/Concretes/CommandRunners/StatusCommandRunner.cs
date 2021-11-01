using ParkingLot.Abstracts;
using ParkingLot.Entities;
using ParkingLot.Services;
using System;
using System.Linq;

namespace ParkingLot.Concretes.CommandRunners
{
    public class StatusCommandRunner : CommandRunner
    {
        public StatusCommandRunner(ParkingLotService parkingLotService) : base(parkingLotService)
        {
        }

        public override void RunCommand(Command command)
        {
           var occupiedSlots = parkingLotService.GetOccupiedSlots();
            if (occupiedSlots.Any())
            {
                foreach (var slot in occupiedSlots) 
                {
                    Console.WriteLine(slot.SlotNumber + "    " + slot.ParkedCar.RegistrationNumber + "    " + slot.ParkedCar.Colour);
                }
            }
            else 
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }

        public override bool ValidateCommand(Command command)
        {
            return command.CommandParams.Count == 0;
        }
    }
}
