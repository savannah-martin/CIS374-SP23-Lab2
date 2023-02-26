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

            foreach (var item in array)
            {
                if (item.CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;

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
            //if (index == Count)
            //{
            //    return;
            //}

            int left = LeftChild(index);
            int right = RightChild(index);

            if (left == Count - 1 && array[index].CompareTo(array[left]) > 0)
            {
                Swap(index, left);
                return;
            }
            if (right == Count - 1 && array[index].CompareTo(array[right]) > 0)
            {
                Swap(index, right);
                return;
            }

            if (left >= Count - 1 || right >= Count - 1)
            {
                return;
            }
            if (array[left].CompareTo(array[right]) < 0 && array[index].CompareTo(array[left]) > 0)
            {
                Swap(index, left);
                TrickleDown(left);
            }
            else if (array[index].CompareTo(array[right]) > 0)
            {
                Swap(index, right);
                TrickleDown(right);
                return;
            }

        }

        // TODO
        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            if (position == 0)
            {
                throw new Exception();
            }
            return (position - 1) / 2;
        }
        // TODO
        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
            if ((2 * position) + 1 > 0)
            {
                return (2 * position) + 1;
            }
            throw new Exception();
        }
        // TODO
        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
            if ((2 * position) + 2 > 0)
            {
                return (2 * position) + 2;
            }
            throw new Exception();
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


