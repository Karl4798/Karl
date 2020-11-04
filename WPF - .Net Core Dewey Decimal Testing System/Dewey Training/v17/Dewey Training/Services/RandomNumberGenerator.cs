using System;

namespace Dewey_Training.Services
{

    // Helper class used to generate random decimal numbers (dewey decimals)
    public static class RandomNumberGenerator
    {

        // Generates a random number within the passed range
        public static string RandomNumber(int min, int max, bool isDecimal)
        {

            // Create a new random object
            Random _random = new Random();

            // Generate a new random number from the object within a set range (min, and max)
            string number = _random.Next(min, max).ToString();

            // If the passed in boolean value is true, then add formatting
            // for Dewey Decimals (the first part e.g. ###)
            if (isDecimal)
            {

                // Formatting for the integer value
                if (number.Length == 2)
                {
                    number = "0" + number;
                }
                if (number.Length == 1)
                {
                    number = "00" + number;
                }

            }

            // Returns the decimal value to the calling method
            return number;
        }

    }

}