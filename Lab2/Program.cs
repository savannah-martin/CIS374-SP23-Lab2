using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap<int> heap0 = new MinHeap<int>();
            heap0.Add(160);
            heap0.Add(130);
            heap0.Add(100);
            heap0.Add(90);
            heap0.Add(60);

            heap0.Update(60, 65);
            Console.WriteLine(heap0.Count);
            Console.WriteLine(heap0.Contains(60));
            Console.WriteLine(heap0.Contains(65));

            heap0.Update(130, 125);
            Console.WriteLine(heap0.Count);
            Console.WriteLine(heap0.Contains(130));
            Console.WriteLine(heap0.Contains(125));

            heap0.Update(90, 95);
            Console.WriteLine(heap0.Count);
            Console.WriteLine(heap0.Contains(90));
            Console.WriteLine(heap0.Contains(95));

            heap0.Update(160, 50);
            Console.WriteLine("should be 5");
            Console.WriteLine(heap0.Count);
            Console.WriteLine(heap0.Contains(160));
            Console.WriteLine(heap0.Contains(50));
            Console.WriteLine("should be 50");
            Console.WriteLine(heap0.Peek());
        }
    }
}

