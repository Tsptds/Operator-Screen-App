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
        private static int entryNo = 0;
        public static void FillGrid(DataGridView grid, Node tail, int listLength)
        {
            if (tail == null || grid == null)
                return;
            entryNo = listLength;

            // Refresh grid columns
            grid.Columns.Clear();
            grid.Columns.Add("entryNo ", "Entry No");

            grid.Columns.Add("logID", "Log ID");
            grid.Columns.Add("computerHash", "Computer Hash");
            grid.Columns.Add("ipAddress", "IP Address");
            grid.Columns.Add("userID", "User ID");
            grid.Columns.Add("username", "Username");
            grid.Columns.Add("accessLocation", "Access Location");
            grid.Columns.Add("accessDirection", "Access Direction");
            grid.Columns.Add("verifyStatusCode", "Verify Status Code");
            grid.Columns.Add("additionalInfo", "Additional Info");
            grid.Columns.Add("logTime", "Log Time");

            // Iterate through the linked list and populate the grid
            Node current = tail;
            for (int i = listLength; i > 0; i--)
            {
                grid.Rows.Add(
                    entryNo,

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
                entryNo--;
                current = current.Prev;
            }
        }
    }
}
