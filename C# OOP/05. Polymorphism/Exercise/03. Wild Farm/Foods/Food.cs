namespace WildLife.Foods
{
    public abstract class Food
    {
        private int quantity;

        public int Quantity
        {
            get => this.quantity;
            set { this.quantity = value; }
        }

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
