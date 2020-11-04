using System;
using System.IO;

namespace Dewey_Training_DAL
{

    public class TreeDataAccess
    {

        public string[] ReadTreeData()
        {

            // Database connection
            var treeDataLoc = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            treeDataLoc += @"TreeData\TreeData.csv";

            string[] lines = File.ReadAllLines(treeDataLoc);

            return lines;

        }

    }

}
