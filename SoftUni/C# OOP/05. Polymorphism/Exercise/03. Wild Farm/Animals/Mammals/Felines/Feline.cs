namespace WildLife.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        private string breed;
        public string Breed { get; protected set; }

        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return
                $"{this.GetType().Name} [{base.Name}, {this.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
