using Dewey_Training.DoublyLinkedList;
using Dewey_Training.Models;
using System.Collections.Generic;

namespace Dewey_Training.Services
{
    public static class SortAlphabetically
    {

        public static LinkedList AlphabetOrder(LinkedList decimals)
        {

            List<string> deweys = new List<string>();
            LinkedList d = new LinkedList();

            foreach (var dec in decimals)
            {
                deweys.Add(dec.Data.Decimal + " " + dec.Data.Author);
            }

            string[] array = deweys.ToArray();

            int a, b, c;

            string[] arr1 = array;
            string temp;

            c = arr1.Length;

            for (a = 0; a < c; a++)
            {
                for (b = 0; b < c - 1; b++)
                {
                    if (arr1[b].CompareTo(arr1[b + 1]) > 0)
                    {
                        temp = arr1[b];
                        arr1[b] = arr1[b + 1];
                        arr1[b + 1] = temp;
                    }
                }
            }

            for (a = 0; a < c; a++)
            {

                d.Add(new DeweyDecimal()
                {
                    Decimal = arr1[a].Split(" ")[0],
                    Author = arr1[a].Split(" ")[1]
                });

            }

            return d;

        }

    }
}
