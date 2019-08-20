namespace ConsoleApp1
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Stats Stats
        {
            get => this.stats;
            private set => this.stats = value;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
    }
}
