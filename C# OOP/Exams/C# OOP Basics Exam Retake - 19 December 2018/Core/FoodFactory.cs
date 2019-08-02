using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts.Models;

namespace SoftUniRestaurant.Core
{
    public class FoodFactory
    {
        private IFood food;

        public IFood GetFood(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Salad":
                    food = new Salad(name, price);
                    break;
                case "Soup":
                    food = new Soup(name, price);
                    break;
                case "MainCourse":
                    food = new MainCourse(name, price);
                    break;
                case "Dessert":
                    food = new Dessert(name, price);
                    break;
            }

            return food;
        }
    }
}
