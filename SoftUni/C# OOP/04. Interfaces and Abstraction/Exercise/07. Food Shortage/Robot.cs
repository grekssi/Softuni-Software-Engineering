namespace BirthdayCelebration
{
    public class Robot : Entered
    {
        public string Name { get; private set; }

        public Robot(string id, string name) 
            : base(id)
        {
            this.Name = name;
        }
    }
}
