using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while (true)
            {
                
                var command = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                if (command[0] == "Tournament")
                {
                    break;
                }
                string trainerName = command[0];
                string pokemonName = command[1];
                string pokemonElements = command[2];
                int pokemonHealth = int.Parse(command[3]);
                var pokemon = new Pokemon(pokemonName, pokemonElements, pokemonHealth);
                bool isadded = false;
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }
                trainers[trainerName].pokemons.Add(pokemon);

            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    foreach (var trainer in trainers.Values.OrderByDescending(x => x.NumberOfBadges))
                    {
                        Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
                    }
                    break;
                }

                
                foreach (var trainer1 in trainers.Values)
                {
                    bool isfound = false;
                    foreach (var pokemon in trainer1.pokemons)
                    {
                        if (pokemon.Element == command)
                        {
                            trainer1.NumberOfBadges++;
                            isfound = true;
                        }

                    }

                    if (!isfound)
                    {
                        trainer1.DecreaseHealth();
                        trainer1.RemoveDeadPokemons();
                    }
                    
                }

                
                
            }
        }
    }
}
