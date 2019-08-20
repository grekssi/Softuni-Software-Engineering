using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            int tomatoCalory = 80;
            int carrotCalory = 136;
            int lettuceCalory = 109;
            int potatoCalory = 215;
            string[] inputOne = Console.ReadLine().Split();
            int[] inputTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<string> vegetables = new Queue<string>(inputOne);
            Stack<int> salads = new Stack<int>(inputTwo);
            Queue<int> result = new Queue<int>();

            while (vegetables.Any() && salads.Any())
            {
                int salad = salads.Peek();

                while (salad > 0 && vegetables.Any())
                {
                    string vegetable = vegetables.Dequeue();
                    if (vegetable == "tomato")
                    {
                        salad -= tomatoCalory;
                    }
                    else if (vegetable == "carrot")
                    {
                        salad -= carrotCalory;
                    }
                    else if (vegetable == "lettuce")
                    {
                        salad -= lettuceCalory;
                    }
                    else if (vegetable == "potato")
                    {
                        salad -= potatoCalory;
                    }
                }
                result.Enqueue(salads.Pop());
            }
            Console.WriteLine(string.Join(" ", result));
            if (salads.Any())
            {
                Console.WriteLine(string.Join(" ", salads));
            }
            if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
