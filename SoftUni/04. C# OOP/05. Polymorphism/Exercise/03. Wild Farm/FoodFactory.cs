using WildLife.Foods;

namespace WildLife
{
    public class FoodFactory
    {
        private Food food;

        public Food Create(string[] input)
        {
            string name = input[0];
            int amount = int.Parse(input[1]);

            switch (name)
            {
                case "Vegetable":
                    food = new Vegetable(amount);
                    break;
                case "Seeds":
                    food = new Seeds(amount);
                    break;
                case "Meat":
                    food = new Meat(amount);
                    break;
                case "Fruit":
                    food = new Fruit(amount);
                    break;
            }

            return food;
        }
    }
}
