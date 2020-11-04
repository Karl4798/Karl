using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// The tower of Hanoi is a set of disks on a rod with smaller disks on top
// The disks must be moved to anther rod
// There are three rods
// We can only move one disk at a time
// A larger disk cannot be placed on a smaller disk

//      |           |           |
//     ___          |           |
//   _______        |           |
// ___________      |           |
// -----------------------------------------
//      A           B           C

namespace TowersOfHanoi
{
    class Program
    {

        static Stack A = new Stack();
        static Stack B = new Stack();
        static Stack C = new Stack();
        static int noOfDisks;
        static bool correctType = false;

        static void Main(string[] args)
        {

            while (correctType == false)
            {
                Console.Write("Please input the number of disks: ");

                try
                {

                    noOfDisks = Int32.Parse(Console.ReadLine());
                    correctType = true;

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Cannot read input, please enter a number.");
                    Console.WriteLine("\n");

                }
            }

            for (int i = 0; i < noOfDisks; i++)
            {
                A.Push(i + 1);
            }

            PrintStacks();
            Move(noOfDisks, A, C, B);

            Console.ReadLine();
            
        }

        public static void Move(int numberOfDisks, Stack from, Stack to, Stack interchange)
        {

            if (numberOfDisks > 0)
            {
                Move(numberOfDisks - 1, from, interchange, to);
                MoveDisk(from, to);
                Move(numberOfDisks - 1, interchange, to, from);

            }

        }

        public static void MoveDisk(Stack from, Stack to)
        {

            var temp = from.Pop();
            to.Push(temp);
            PrintStacks();

        }

        public static void PrintStacks()
        {
            Console.Write("A: ");
            foreach (var item in A)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("B: ");
            foreach (var item in B)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("C: ");
            foreach (var item in C)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

        }

    }
}
