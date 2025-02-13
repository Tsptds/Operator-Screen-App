using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operator_Screen_App.Items.Log;

namespace Operator_Screen_App.Items.Node
{
    public class Node
    {
        public LogEntry? Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev {  get; set; }

        public Node(LogEntry log) { 
            Data = log;
            Next = null;
            Prev = null;
        }
    }

    public class NodeList
    {
        public Node? head { get; set; }

        public void Append(LogEntry log)
        {
            if (head == null)
            {
                head = new Node(log);
                MessageBox.Show($"Node with username {head.Data?.username} added to list");
            }
            else {
                Node current = head;
                //MessageBox.Show("Searching node");
                while (current.Next != null) {
                    current = current.Next;
                }
                //MessageBox.Show("Found Node");
                current.Next = new Node(log) { Prev = current};
                MessageBox.Show($"Node with username {current.Data.username} added to list");
            }

        }

        public void Print()
        {
            Node? current = head;
            var result = DialogResult.OK;
            while (current != null && result == DialogResult.OK)
            {
                result = MessageBox.Show(
                    "username:\t\t "            + current.Data.username         + "\n" +
                    "logID:\t\t "               + current.Data.logID            + "\n" +
                    "computerHash:\t "          + current.Data.computerHash     + "\n" +
                    "ipAddress:\t\t "           + current.Data.ipAddress        + "\n" +
                    "userID:\t\t "              + current.Data.userID           + "\n" +
                    "accessLocation:\t "        + current.Data.accessLocation   + "\n" +
                    "accessDirection:\t "       + current.Data.accessDirection  + "\n" +
                    "verifyStatusCode:\t "      + current.Data.verifyStatusCode + "\n" +
                    "additionalInfo:\t "        + current.Data.additionalInfo   + "\n" +
                    "logTime:\t\t "             + current.Data.logTime,
                    
                "Log Entry Information", MessageBoxButtons.OKCancel);

                current = current.Next;
            }
        }

        // Takes the grid object and assigns the cols of LogEntry
        public void AssignContentToGrid(DataGridView grid)
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
