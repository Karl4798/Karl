using Dewey_Training.DoublyLinkedList;
using Dewey_Training.Models;
using System.Collections.Generic;

namespace Dewey_Training.Services
{

    // Helper class used to sort a Doubly Linked List (custom implementation) alphabetically
    public static class SortAlphabetically
    {

        // Method used to sort the Doubly Linked List (custom implementation) alphabetically
        public static LinkedList AlphabetOrder(LinkedList decimals)
        {

            // List<T> used to store doubly linked list elements temporarily
            List<string> deweys = new List<string>();

            // LinkedList used to store dewey decimal values
            LinkedList deweyValues = new LinkedList();

            // Adds all dewey decimal object values to a List<T>
            foreach (var dec in decimals)
            {
                deweys.Add(dec.Data.Decimal + " " + dec.Data.Author);
            }

            // Converts the List<T> to an array for sorting
            string[] array = deweys.ToArray();

            // Index integers used during the sorting of the deweys list
            int a, b, c;

            // Bubble sort algorithm used to order values alphabetically
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

            // Adds the sorted list to the temporary Doubly Linked List deweyValues
            for (a = 0; a < c; a++)
            {

                deweyValues.Add(new DeweyDecimal()
                {
                    Decimal = arr1[a].Split(" ")[0],
                    Author = arr1[a].Split(" ")[1]
                });

            }

            // Returns the sorted Doubly Linked List with Dewey Decimals alphabetically ordered
            return deweyValues;

        }

    }

}
