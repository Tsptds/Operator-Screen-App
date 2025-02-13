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
            while (current != null)
            {
                MessageBox.Show(current.Data.username.ToString(), $"LOG ID {current.Data.logID.ToString()}");

                current = current.Next;
            }
        }
    }
}
