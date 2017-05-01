using System.Collections.Generic;
using System;

namespace ConsoleApp2
{
    public class Program
    {
        static int NodeCount = 1;
        static void Main(string[] args)
        {
            
            Node<Int32> root = new Node<int>(1);
            root = Generate(root);
            List<Int32> order  = root.LevelOrder();
            foreach (int num in order)
                Console.Write(num + " ");
            Console.ReadKey();
        }
        static Node<int> Generate(Node<int> root)
        {
            Random rand = new Random();
            root.AddAllChildren(Make(rand.Next(0, 5)));
            for (int i = 0; i < root.children.Count; i++)
                root.children[i] = Generate(root.children[i]);
            return root;
        }
        static List<Node<int>> Make(int children) {
            List<Node<int>> list = new List<Node<int>>();
            if (NodeCount > 100)
                return list;
            for (int i = 1; i <= children; i++)
            {
                NodeCount++;
                list.Add(new Node<int>(NodeCount));
            }
            return list;
        }
    }
}
