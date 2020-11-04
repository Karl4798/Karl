using System;
using System.Collections.Generic;

namespace Dewey_Training.Services
{

    // Helper class used to shuffle List<T>'s
    public static class ShuffleExtension
    {

        // Method used to shuffle List<T>'s
        public static void Shuffle<T>(this IList<T> list)
        {

            // Random generator used to shuffle the passed in List<T>
            Random _random = new Random();

            // Gets the length / size of the list
            int n = list.Count;

            // While the length of the list is greater than 0, shuffle the elements
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
