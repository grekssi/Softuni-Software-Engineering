using System;
using System.Linq;
using MXGP.IO;

namespace MXGP.Core.Contracts
{
    class Engine : IEngine
    {
        ConsoleReader consoleReader = new ConsoleReader();
        ConsoleWriter consoleWriter = new ConsoleWriter();
        ChampionshipController controller = new ChampionshipController();
        public void Run()
        {
            ;
            while (true)
            {
                var command = consoleReader.ReadLine().Split(' ').ToArray();
                string mainCommand = command[0];
                try
                {
                    switch (mainCommand)
                    {
                        case "CreateRider":
                            string name = command[1];
                            Console.WriteLine(controller.CreateRider(name));
                            break;
                        case "CreateMotorcycle":
                            string type = command[1];
                            string model = command[2];
                            int hp = int.Parse(command[3]);
                            Console.WriteLine(controller.CreateMotorcycle(type, model, hp));
                            break;
                        case "AddMotorcycleToRider":
                            string riderName = command[1];
                            string motorcycleName = command[2];
                            Console.WriteLine(controller.AddMotorcycleToRider(riderName, motorcycleName));
                            break;
                        case "AddRiderToRace":
                            string raceName = command[1];
                            riderName = command[2];
                            Console.WriteLine(controller.AddRiderToRace(raceName, riderName));
                            break;
                        case "CreateRace":
                            name = command[1];
                            int laps = int.Parse(command[2]);
                            Console.WriteLine(controller.CreateRace(name, laps));
                            break;
                        case "StartRace":
                            name = command[1];
                            Console.WriteLine(controller.StartRace(name));
                            break;
                        case "End":
                            return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
           
        }
    }
}
