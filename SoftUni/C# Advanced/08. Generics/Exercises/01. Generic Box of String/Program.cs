using System;

namespace GenericsBoxOfStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mybox = new Box<string>();
            var inputsize = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsize; i++)
            {
                string input = Console.ReadLine();
                mybox.Add(input);
            }

            Console.WriteLine(mybox.ToString());

        }
    }
}
