using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operator_Screen_App.Items.Node;

namespace Operator_Screen_App.Logics
{
    internal class FillGridView
    {
        public static void FillGrid(DataGridView grid, Node head)
        {
            if (head == null || grid == null)
                return;

            // Ensure the grid has the appropriate columns
            grid.Columns.Clear();
            grid.Columns.Add("logID", "logID");
            grid.Columns.Add("computerHash", "computerHash");
            grid.Columns.Add("ipAddress", "ipAddress");
            grid.Columns.Add("userID", "userID");
            grid.Columns.Add("username", "username");
            grid.Columns.Add("accessLocation", "accessLocation");
            grid.Columns.Add("accessDirection", "accessDirection");
            grid.Columns.Add("verifyStatusCode", "verifyStatusCode");
            grid.Columns.Add("additionalInfo", "additionalInfo");
            grid.Columns.Add("logTime", "logTime");

            // Iterate through the linked list and populate the grid
            Node current = head;
            while (current != null)
            {
                grid.Rows.Add(
                    current.Data.logID,
                    current.Data.computerHash,
                    current.Data.ipAddress,
                    current.Data.userID,
                    current.Data.username,
                    current.Data.accessLocation,
                    current.Data.accessDirection,
                    current.Data.verifyStatusCode,
                    current.Data.additionalInfo,
                    current.Data.logTime
                );

                current = current.Next;
            }
        }
    }
}
