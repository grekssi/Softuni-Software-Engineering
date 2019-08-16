namespace BirthdayCelebration
{
    public class Pet : IBirthable
    {
        private string name;

        public string BirthDate { get; private set; }
        public string Name { get; private set; }

        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
    }
}
