using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap<string> heap1 = new MinHeap<string>();

            heap1.Add("kaden");
            heap1.Add("caleb");
            heap1.Add("kenan");
            heap1.Add("dallas");
            heap1.Add("cameron");

            Console.WriteLine(heap1.ExtractMin());
            Console.WriteLine(heap1.ExtractMin());
            Console.WriteLine(heap1.ExtractMin());
            Console.WriteLine(heap1.ExtractMin());
            Console.WriteLine(heap1.ExtractMin());
        }
    }
}

