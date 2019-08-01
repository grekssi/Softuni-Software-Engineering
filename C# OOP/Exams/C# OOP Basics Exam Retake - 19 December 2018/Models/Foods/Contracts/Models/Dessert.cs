namespace SoftUniRestaurant.Models.Foods.Contracts.Models
{
    public class Dessert : Food
    {
        //InitialServingSize - 200
        private const int InitialServingSize = 200;
        public Dessert(string name, decimal price)
            : base(name, InitialServingSize, price)
        {
        }
    }
}
