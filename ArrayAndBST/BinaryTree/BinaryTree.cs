using System;
using System.Collections;
using System.Collections.Generic; 

namespace BinaryTreeSpace
{
    public class  BinaryTree<T> where T : IComparable <T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }


        public event Action AddNewNode;


        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count++;
                AddNewNode?.Invoke();  
                return;
            }

            Root.Add(data);
            AddNewNode?.Invoke();
            Count++;
        }

        public Node<T> Find(T data)
        {
            if (Root.Data == null)
            {
                throw new Exception("Tree is empty");
            }

            return Find(Root, data);
        }


        private Node<T> Find(Node<T> current, T dataToFind)
        {
            if (current == null)
            {
                throw new Exception($"Tree does not include {dataToFind.ToString()}");
            }

            if (current.Data.CompareTo(dataToFind) == 0)
            {
                return current;
            }
            else if (current.Data.CompareTo(dataToFind) > 0)
            {
                return Find(current.Left, dataToFind);
            }
            else 
            {
                return Find(current.Right, dataToFind);
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Root != null)
            {
                return Detour(Root).GetEnumerator();
            }
            else
            {
                throw new Exception("The tree does not contain any data. First add some data.");
            }
        }

        private List<T> Detour(Node<T> node)
        {
            List<T> DataList = new List<T>();

            DataList.Add(node.Data);

            if (node.Left != null)
            {
                DataList.AddRange(Detour(node.Left));
            }

            if (node.Right !=null)
            {
                DataList.AddRange(Detour(node.Right));
            }

            return DataList;
        }




    }
}
