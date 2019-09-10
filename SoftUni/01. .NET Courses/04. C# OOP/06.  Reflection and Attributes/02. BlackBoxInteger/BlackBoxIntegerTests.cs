using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Instantiate(Type type)
        {
            
        }

        public static void Run(Type type)
        {
            var currentType = Activator.CreateInstance(type, true);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            while (true)
            {
                var command = Console.ReadLine().Split('_').ToArray();
                if (command[0] == "END")
                {
                    break;
                }
                int value = int.Parse(command[1]);
                object[] parameters = new Object[] { value };
                switch (command[0])
                {
                    case "Add":
                        methods.FirstOrDefault(x => x.Name == "Add").Invoke(currentType, parameters);
                        break;
                    case "Subtract":
                        methods.FirstOrDefault(x => x.Name == "Subtract").Invoke(currentType, parameters);
                        break;
                    case "Multiply":
                        methods.FirstOrDefault(x => x.Name == "Multiply").Invoke(currentType, parameters);
                        break;
                    case "Divide":
                        methods.FirstOrDefault(x => x.Name == "Divide").Invoke(currentType, parameters);
                        break;
                    case "LeftShift":
                        methods.FirstOrDefault(x => x.Name == "LeftShift").Invoke(currentType, parameters);
                        break;
                    case "RightShift":
                        methods.FirstOrDefault(x => x.Name == "RightShift").Invoke(currentType, parameters);
                        break;
                }
                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                Console.WriteLine(fields.FirstOrDefault(x => x.Name == "innerValue").GetValue(currentType));
            }
        }

        public static void Main()
        {
            Run(typeof(BlackBoxInteger));
        }
    }
}
