using System;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {  try
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                string name = input[1];
                Pizza pizza = new Pizza(name);

                input = Console.ReadLine().Split(' ').ToArray();

                string flour = input[1];
                string typeBake = input[2];
                decimal weight = decimal.Parse(input[3]); //WARNING MAY BREAK
                Dough dough = new Dough(flour, typeBake, weight);
                pizza.AddDough(dough);

                while (true)
                {
                    var toppingInput = Console.ReadLine().Split(' ').ToArray();
                    if (toppingInput[0] == "END")
                    {
                        Console.WriteLine(pizza);
                        break;
                    }
                    string type = toppingInput[1];
                    decimal toppingWeight = decimal.Parse(toppingInput[2]);
                    Topping topping = new Topping(type, toppingWeight);
                    pizza.Add(topping);
                }
                  
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
            
        }
    }
}
