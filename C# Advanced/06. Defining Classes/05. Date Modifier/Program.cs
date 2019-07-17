using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace classesDateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine().Split(' ').ToArray();
            var secondDate = Console.ReadLine().Split(' ').ToArray();
            var startdate = DateTime.ParseExact($"{firstDate[2]}/{firstDate[1]}/{firstDate[0]}",
                "dd/MM/yyyy", new CultureInfo("bg-BG"));
            var enddate = DateTime.ParseExact($"{secondDate[2]}/{secondDate[1]}/{secondDate[0]}",
                "dd/MM/yyyy", new CultureInfo("bg-BG"));

            var Date = new DateModifier();
            Console.WriteLine(Date.getDays(startdate, enddate));
        }
    }
}
