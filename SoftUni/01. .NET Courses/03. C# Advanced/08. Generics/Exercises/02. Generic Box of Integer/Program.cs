using System;

namespace GenericsBoxOfStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mybox = new Box<int>();
            var inputsize = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsize; i++)
            {
                int input = int.Parse(Console.ReadLine());
                mybox.Add(input);
            }

            Console.WriteLine(mybox.ToString());

        }
    }
}
