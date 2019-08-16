using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Drinks.Models;

namespace SoftUniRestaurant.Core
{
    public class DrinksFactory
    {
        private IDrink drink;

        public IDrink GetDrink(string type, string name, int servingSize, string brand)
        {
            switch (type)
            {
                case "Water":
                    drink = new Water(name, servingSize, brand);
                    break;
                case "Juice":
                    drink = new Juice(name, servingSize, brand);
                    break;
                case "FuzzyDrink":
                    drink = new FuzzyDrink(name, servingSize, brand);
                    break;
                case "Alcohol":
                    drink = new Alcohol(name, servingSize, brand);
                    break;
            }

            return drink;
        }
    }
}
