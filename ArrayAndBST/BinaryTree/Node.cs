using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeSpace
{
    public class Node<T> : IComparable<T> where T : IComparable<T>
    {
        public T Data { get;  set; }

        public Node<T> Left { get;  set; }
        public Node<T> Right { get;  set; }

        public Node(T Data)
        {
            this.Data = Data;
        }

        
        public void Add(T data)
        {
            var newNode = new Node<T>(data);
            

            if (newNode.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = newNode;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = newNode;
                }
                else
                {
                    Right.Add(data);
                }

            }
        }

        public override string ToString()
        {
            return Data.ToString(); 
        }

       

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
