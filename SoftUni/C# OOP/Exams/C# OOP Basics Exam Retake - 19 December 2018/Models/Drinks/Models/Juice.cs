using System.Runtime.CompilerServices;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Models.Drinks.Models
{
    class Juice : Drink
    {
        private const decimal JuicePrice = 1.80m;
        public Juice(string name, int servingSize, string brand)
            : base(name, servingSize, JuicePrice, brand)
        {
        }
    }
}
