using System;
using System.Linq;

namespace Lab2
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;


        public MinHeap(T[] initialArray = null)
        {
            array = new T[initialSize];

            if (initialArray == null)
            {
                return;
            }

            foreach (var item in initialArray)
            {
                Add(item);
            }

        }

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(?).
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        // TODO
        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(?).
        /// </summary>
        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(nextEmptyIndex);

            Count++;

            // resize if full
            if (Count == Capacity)
            {
                DoubleArrayCapacity();
            }

        }

        public T Extract()
        {
            return ExtractMin();
        }

        // TODO
        /// <summary>
        /// Removes and returns the max item in the min-heap.
        /// Time complexity: O( N ).
        /// </summary>
        public T ExtractMax()
        {
            // linear search
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T max = array[0];
            int pos = 0; 
            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                    pos = i;
                }
            }
            array[pos] = default;

            Count--;

            return max;
        }

        // TODO
        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time copmlexity: O( log(n) ).
        /// </summary>
        public T ExtractMin()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T min = array[0];

            // swap root (first) and last element
            Swap(0, Count - 1);

            // "remove" last
            Count--;

            // trickle down from root (first)
            TrickleDown(0);

            return min;
        }

        // TODO
        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O( N ).
        /// </summary>
        public bool Contains(T value)
        {
            // linear search

            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;

        }

        // TODO
        /// <summary>
        /// Updates the first element with the given value from the heap.
        /// Time complexity: O( ? )
        /// </summary>
        public void Update(T oldValue, T newValue)
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            if (!Contains(oldValue))
            {
                return;
            }

            //getvalue
            int pos = 0;
            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(oldValue) == 0)
                {
                    array[i] = newValue;
                    pos = i;
                }
            }

            if (array[pos].CompareTo(array[Parent(pos)]) < 0)
            {
                TrickleDown(pos);
            }


        }

        // TODO
        /// <summary>
        /// Removes the first element with the given value from the heap.
        /// Time complexity: O( ? )
        /// </summary>
        public void Remove(T value)
        {

            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            //getvalue
            int pos = 0;
            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) > 0)
                {
                    pos = i;
                }
            }

            // swap root (first) and last element
            Swap(pos, Count - 1);

            Count--;
            TrickleDown(0);
        }


        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parent = Parent(index);
            if (array[index].CompareTo(array[parent]) < 0)
            {
                Swap(index, parent);
                TrickleUp(parent);
            }
            return;

        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleDown(int index)
        {
            if (index == Count)
            {
                return;
            }

            int left = LeftChild(index);
            int right = RightChild(index);
            T curr = array[index];

            if (right > Count)
            {
                return;
            }

            T leftkid = array[left];
            T rightkid = array[right];

            if (curr.CompareTo(leftkid) > 0 || curr.CompareTo(rightkid) > 0)
            {
                if (rightkid.CompareTo(leftkid) < 0 && right < Count)
                {
                    Swap(index, right);
                    TrickleDown(right);

                }
                if (leftkid.CompareTo(rightkid) < 0 && left < Count)
                {
                    Swap(index, left);
                    TrickleDown(left);

                    return;
                }
                if (curr.CompareTo(leftkid)>0 && left == Count - 1)
                {
                    Swap(index, left);
                }
            }
        }

        // TODO
        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            return (position - 1) / 2;
        }
        // TODO
        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
                return (2 * position) + 1;
        }
        // TODO
        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
                return (2 * position) + 2;
        }

        private void Swap(int index1, int index2)
        {
            var temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }


    }
}


