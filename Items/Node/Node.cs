using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Logics;

namespace Operator_Screen_App.Items.Node
{
    public class Node
    {
        public LogEntry? Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev {  get; set; }

        public Node(LogEntry log)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("Constructing new node");

            Data = log;
            Next = null;
            Prev = null;
        }
    }

    public class NodeList
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Node? head { get; set; }
        public Node? tail { get; set; }
        public int listLength = 0;

        public void Append(LogEntry log)
        {
            if (head == null)
            {
                head = new Node(log);
                tail = head;
                //MessageBox.Show($"Node with username {head.Data?.username} added to list");
            }
            else {
                tail.Next = new Node(log) { Prev = tail};
                tail = tail.Next;
                //MessageBox.Show($"Node with username {tail.Data.username} added to list");
            }
            listLength++;
        }

        public void Print()
        {
            logger.Info("Displaying All Entries");

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
        public void AssignContentToGrid(int listLength, DataGridView grid)
        {
            logger.Info("Refreshing Grid");
            FillGridView.FillGrid(grid, tail, listLength);
        }
    }
}
