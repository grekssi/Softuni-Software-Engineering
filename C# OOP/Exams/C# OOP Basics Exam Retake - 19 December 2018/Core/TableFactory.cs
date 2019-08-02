using SoftUniRestaurant.Models.Tables.Contracts;
using SoftUniRestaurant.Models.Tables.Models;

namespace SoftUniRestaurant.Core
{
    public class TableFactory
    {
        private ITable table;

        public ITable GetTable(string type, int number, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    table = new InsideTable(number, capacity);
                    break;
                case "Outside":
                    table = new OutsideTable(number, capacity);
                    break;
            }

            return table;
        }
    }
}
