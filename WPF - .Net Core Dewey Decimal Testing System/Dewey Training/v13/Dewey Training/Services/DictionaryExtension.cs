using System;
using System.Collections.Generic;
using System.Linq;

namespace Dewey_Training.Services
{

    // Extension for Dictionaries, allowing them to be shuffled,
    // but keep their key/ value pairs the same
    public static class DictionaryExtension
    {

        // Method used to shuffle dictionaries
        public static Dictionary<TKey, TValue> Shuffle<TKey, TValue>(
           this Dictionary<TKey, TValue> source)
        {

            // Random generator
            Random r = new Random();

            // Returns the dictionary in a shuffled state
            return source.OrderBy(x => r.Next())
               .ToDictionary(item => item.Key, item => item.Value);
        }
    }
}
