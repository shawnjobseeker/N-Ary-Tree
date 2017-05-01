using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    
    public class Node<T>
    {
        public T data { get; private set; }
        public Node<T> parent { get; private set; }
        public List<Node<T>> children { get; private set; }
        public Node(T data)
        {
            this.data = data;
            this.children = new List<Node<T>>();
        }
        public override string ToString()
        {
            return data.ToString();
        }
        public void AddChild(Node<T> data)
        {
            data.parent = this;
            this.children.Add(data);
        }
        public void AddAllChildren(List<Node<T>> children)
        {
            foreach (Node<T> child in children)
                child.parent = this;
            this.children.AddRange(children);
        }
        public bool IsLeaf()
        {
            return this.children == null || this.children.Count == 0;
        }
        public List<T> PreOrder()
        {
            List<T> list = new List<T>();
            list.Add(data);
            foreach (Node<T> child in children)
                list.AddRange(child.PreOrder());
            return list;
        }
        public List<T> PostOrder()
        {
            List<T> list = new List<T>();
            foreach (Node<T> child in children)
                list.AddRange(child.PreOrder());
            list.Add(data);
            return list;
        }
        public List<T> LevelOrder()
        {
            List<T> list = new List<T>();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(this);
            while(queue.Count != 0)
            {
                Node<T> temp = queue.Dequeue();
                foreach (Node<T> child in temp.children)
                    queue.Enqueue(child);
                list.Add(temp.data);
            }
            return list;
        }
        public int Depth()
        {
                int deepest = 0;
                foreach(Node<T> child in children)
                {
                    int depth = 1 + child.Depth();
                    if (deepest < depth)
                        deepest = depth;
                }
                return deepest;
        }
    }
}
