namespace ParkingLot.Entities
{
    public class Car
    {
        private readonly string registrationNumber;
        private readonly string colour;

        public Car(string regNo, string colour)
        {
            registrationNumber = regNo;
            this.colour = colour;
        }

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
        }

        public string Colour
        {
            get
            {
                return colour;
            }
        }
    }
}
