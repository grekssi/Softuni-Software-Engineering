using System;
using System.ComponentModel.Design;
using System.Linq;

namespace ConsoleApp233
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyOperator<string> current = new ListyOperator<string>();

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToList();
                if (command[0] == "Create")
                {
                    try
                    {
                        command.RemoveAt(0);
                        current = new ListyOperator<string>(command.ToArray());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("no elements test");
                        throw;
                    }
                }
                else if (command[0] == "Move")
                {
                    Console.WriteLine(current.Move());
                }
                else if (command[0] == "Print")
                {
                    current.Print();
                }
                else if (command[0] == "HasNext")
                {
                    Console.WriteLine(current.HasNext());
                }
                else if (command[0] == "PrintAll")
                {
                    foreach (var item in current)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                else if (command[0] == "END")
                {
                    break;
                }
            }
        }
    }
}
