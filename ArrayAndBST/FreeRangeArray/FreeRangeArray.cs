using System;
using System.Collections;
using System.Collections.Generic;

namespace FreeArray
{
    public class FreeRangeArray<T> : ICollection<T> where T : IComparable//, IEnumerable
    {
        public int Length { get; private set; }
        public int startIndex { get; private set; }
        public int endIndex { get; private set; }

        private T[] Array;

        public FreeRangeArray(int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
                throw new Exception("The ending index must be greather then the start index");
            if (startIndex == endIndex)
                throw new Exception("The ending index must be graether then the start index");

            this.startIndex = startIndex;
            this.endIndex = endIndex;
            Length = endIndex - startIndex + 1;
            Array = new T[Length];
        }

        public FreeRangeArray(int startIndex, T[] Array)
        {
            if (Array == null)
                throw new Exception("Array equals null ");

            this.Array = Array;
            this.startIndex = startIndex;
            endIndex = Array.Length - Math.Abs(startIndex) - 1;
        }

        public T this[int i]
        {

            get
            {
                if (i > endIndex || startIndex > i)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                int itetatorI = Math.Abs(startIndex - i);
                return Array[itetatorI];
            }
            set
            {
                
                if (i > endIndex || startIndex > i)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                int itetatorI = Math.Abs(startIndex - i);
                Array[itetatorI] = value;
            }

            
        }


        #region ICollection

        public int Count => Length;

        public bool IsReadOnly => true;


        public void CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("Array cannot be null.");
            if (index < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if ((index > endIndex || startIndex > index) &&
                index + array.Length > endIndex)
                throw new IndexOutOfRangeException("Index out of range");
            


            for (int i = 0; i < index; i++)
            {
                array[i] = Array[i - startIndex];
            }

        }

        


        public IEnumerator GetEnumerator()
        {
            return Array.GetEnumerator();
        }

       
        public void Add(T item)
        {
            T[] temp = new T[Array.Length + 1];
            for (int i = 0; i < Array.Length; i++)
            {
                temp[i] = Array[i];
            }
            temp[Length] = item;
            Array = temp;
            Length++;
            endIndex++;
        }

        public void Clear()
        {
            if (Array is ValueType)
            {
                for (int i = 0; i < Length; i++)
                {
                    Array[i] = default(T);
                }
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    //GC.Collect();
                    (Array as IList).Clear();
                }
            }
            
        }

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Item cannot be null.");

            
            foreach(var i in Array)
            {
                if (item.CompareTo(i) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(T item)
        {
            bool result = Contains(item);

            if (result)
            {
                T[] newArray = new T[Length - 1];

                int j = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (item.CompareTo(Array[i]) != 0)
                    {
                        newArray[j] = Array[i];
                        j++;
                    }  
                }

                Array = newArray;
                
                Length--;
                endIndex--;
            }
            

            return result;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        #endregion
    }
}
