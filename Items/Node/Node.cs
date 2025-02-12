﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operator_Screen_App.Items.Log;

namespace Operator_Screen_App.Items.Node
{
    internal class Node
    {
        public LogEntry? Data { get; set; }
        public Node? Next { get; set; }

        public Node(LogEntry log) { 
            Data = log;
            Next = null;
        }
    }

    public class LogList
    {
        private Node? head;

        public void Append(LogEntry log)
        {
            //head ??= head = new Node(log);
            if (head == null) 
                head = new Node(log);

            else { 
                Node current = head;
                MessageBox.Show("Node isn't null");
                while (current.Next != null) {
                    current = current.Next;
                }
                MessageBox.Show("Found Node");
                current.Next = new Node(log);
            }
        }

        public void Print()
        {
            Node? current = head;
            while (current != null)
            {
                Console.WriteLine(current.ToString());
            }
        }
    }
}
