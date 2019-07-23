using System;
using System.Collections.Generic;
using System.Text;
using WildLife.Animals;
using WildLife.Animals.Birds;
using WildLife.Animals.Mammals;
using WildLife.Animals.Mammals.Felines;

namespace WildLife
{
    class AnimalFactory
    {
        private Animal animal;
        public Animal Create(string[] input)
        {
            string type = input[0];
            string name = input[1];

            switch (type)
            {
                case "Cat":
                    double weight = double.Parse(input[2]);
                    string livingRegion = input[3];
                    string breed = input[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;

                case "Tiger":
                    weight = double.Parse(input[2]);
                    livingRegion = input[3];
                    breed = input[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;

                case "Hen":
                    weight = double.Parse(input[2]);
                    double wingSize = double.Parse(input[3]);
                    animal = new Hen(name, weight, wingSize);
                    break;

                case "Owl":
                    weight = double.Parse(input[2]);
                    wingSize = double.Parse(input[3]);
                    animal = new Owl(name, weight, wingSize);
                    break;

                case "Mouse":
                    weight = double.Parse(input[2]);
                    livingRegion = input[3];
                    animal = new Mouse(name, weight, livingRegion);
                    break;

                case "Dog":
                    weight = double.Parse(input[2]);
                    livingRegion = input[3];
                    animal = new Dog(name, weight, livingRegion);
                    break;
            }

            return animal;
        }
    }
}
