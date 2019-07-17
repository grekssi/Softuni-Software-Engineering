using System;
using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks.Sources;

namespace tuplegenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');
            string firstname = firstLine[0] + " " + firstLine[1];
            string city = firstLine[2];
            var firstTuple = new Tuple<string,string>(firstname, city);
            Console.WriteLine($"{firstTuple.item1} -> {firstTuple.item2}");

            var secondLine = Console.ReadLine().Split(' ');
            string name = secondLine[0];
            int liters = int.Parse(secondLine[1]);
            var secondTuple = new Tuple<string, int>(name, liters);
            Console.WriteLine($"{secondTuple.item1} -> {secondTuple.item2}");

            var thirdline = Console.ReadLine().Split(' ');
            int integer = int.Parse(thirdline[0]);
            double doubler = double.Parse(thirdline[1]);
            var thirdTuple = new Tuple<int, double>(integer, doubler);
            Console.WriteLine($"{thirdTuple.item1} -> {thirdTuple.item2}");

        }
    }
}
