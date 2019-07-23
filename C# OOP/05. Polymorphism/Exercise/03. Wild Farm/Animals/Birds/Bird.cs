namespace WildLife.Animals.Birds
{
    public abstract class Bird : Animal
    {

        private double wingSize;
        public double WingSize { get; protected set; }

        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
        }
    }
}
