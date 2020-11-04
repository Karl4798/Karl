using System;
using System.Text;

namespace Dewey_Training.Services
{

    // Helper class used to generate a random string of characters
    public static class RandomStringGenerator
    {

        // Generates a random string with a given size (length)
        public static string RandomString(int size, bool lowerCase = false)
        {

            // Create a new random object
            Random _random = new Random();

            // Use string builder to generate the string of characters
            var builder = new StringBuilder(size);

            // Determine if the string values can be lowercase - default is uppercase
            char offset = lowerCase ? 'a' : 'A';

            // Total number of possible characters (26)
            const int lettersOffset = 26;

            // Generate a string of characters by appending new random letters
            // to the string for the length of the passed in "size" parameter
            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            // Returns the string of characters to the calling method
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

    }

}

// Unicode / ASCII Letters are divided into two blocks
// (Letters 65–90 / 97–122):
// The first group containing the uppercase letters and
// the second group containing the lowercase letters