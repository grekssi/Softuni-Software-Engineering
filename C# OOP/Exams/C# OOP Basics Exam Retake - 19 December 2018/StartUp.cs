using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using SoftUniRestaurant.Core;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            RestaurantController restaurantController = new RestaurantController();
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                string mainCommand = input[0];
                if (mainCommand == "END")
                {
                    Console.WriteLine(restaurantController.GetSummary());
                    break;
                }

                try
                {
                    switch (mainCommand)
                    {
                        case "AddFood":
                            Console.WriteLine(restaurantController.AddFood(input[1], input[2], decimal.Parse(input[3])));
                            break;
                        case "AddDrink":
                            Console.WriteLine(restaurantController.AddDrink(input[1], input[2], int.Parse(input[3]), input[4]));
                            break;
                        case "AddTable":
                            Console.WriteLine(restaurantController.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3])));
                            break;
                        case "ReserveTable":
                            Console.WriteLine(restaurantController.ReserveTable(int.Parse(input[1])));
                            break;
                        case "OrderFood":
                            Console.WriteLine(restaurantController.OrderFood(int.Parse(input[1]), input[2]));
                            break;
                        case "OrderDrink":
                            Console.WriteLine(restaurantController.OrderDrink(int.Parse(input[1]), input[2], input[3]));
                            break;
                        case "LeaveTable":
                            Console.WriteLine(restaurantController.LeaveTable(int.Parse(input[1])));
                            break;
                        case "GetFreeTablesInfo":
                            Console.WriteLine(restaurantController.GetFreeTablesInfo());
                            break;
                        case "GetOccupiedTablesInfo":
                            Console.WriteLine(restaurantController.GetOccupiedTablesInfo());
                            break;
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
