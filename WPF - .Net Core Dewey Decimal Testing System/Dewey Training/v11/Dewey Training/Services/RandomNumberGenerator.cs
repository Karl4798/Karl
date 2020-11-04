using System;

namespace Dewey_Training.Services
{
    public static class RandomNumberGenerator
    {

        // Generates a random number within a range.      
        public static string RandomNumber(int min, int max, bool isDecimal)
        {

            Random _random = new Random();
            string number = _random.Next(min, max).ToString();

            if (isDecimal)
            {
                if (number.Length == 2)
                {
                    number = "0" + number;
                }
                if (number.Length == 1)
                {
                    number = "00" + number;
                }
            }

            return number;
        }

    }
}
