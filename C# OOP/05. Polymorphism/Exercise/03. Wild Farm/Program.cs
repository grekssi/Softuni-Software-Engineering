using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WildLife.Animals;
using WildLife.Foods;

namespace WildLife
{
    public class Program
    {
        static void Main()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            Sounds sound = new Sounds();

            var animals = new List<Animal>();
            while (true)
            {
                var inputAnimal = Console.ReadLine().Split(' ').ToArray();
                if (inputAnimal[0] == "End")
                {
                    break;
                }
                Animal animal = animalFactory.Create(inputAnimal);
                Console.WriteLine(
                    sound.ProduceSound(
                        animal
                            .GetType()
                            .Name
                            .ToLower()));
                var inputFood = Console.ReadLine().Split(' ').ToArray();
                Food food = foodFactory.Create(inputFood);
                if (animal.Edibles.Contains(food.GetType().Name))
                {
                    animal.Feed(food.Quantity);
                    animal.FoodEaten += food.Quantity;
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                }
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
