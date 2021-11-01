namespace ParkingLot.Helpers
{
    public static class IntegerHelper
    {
        public static bool IsInteger(string numString)
        {
            var isNum = int.TryParse(numString, out int number);
            return isNum;
        }
    }
}
