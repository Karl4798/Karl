using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Dewey_Training.Services
{

    // Helper class used for getting data grid rows
    public static class DataGridExtension
    {

        // Method used to get data grid rows
        public static IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {

            // Gets the item source from the passed DataGrid object
            var itemsSource = grid.ItemsSource as IEnumerable;

            // Return null if the item source is null
            if (null == itemsSource) yield return null;

            // Return the rows of the data grid if it is not null
            foreach (var item in itemsSource)
            {

                // Gets each row of the data grid
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                // If the row is not equal to null, return the row
                if (null != row) yield return row;
            }
        }

    }
}
