using System;
using System.IO;

namespace Dewey_Training_DAL
{

    // Class used to access the CSV file which stores tree data
    public class TreeDataAccess
    {

        // Method used to read tree data (from a CSV) into the tree structure
        public string[] ReadTreeData()
        {

            // CSV Location
            var treeDataLoc = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            treeDataLoc += @"TreeData\TreeData.csv";

            // Fetches an array of all lines in the CSV file
            string[] lines = File.ReadAllLines(treeDataLoc);

            // Returns the lines
            return lines;

        }

    }

}