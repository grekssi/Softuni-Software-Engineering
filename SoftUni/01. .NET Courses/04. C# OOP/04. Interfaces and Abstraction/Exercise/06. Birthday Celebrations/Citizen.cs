namespace BirthdayCelebration
{
    public class Citizen : Entered, IBirthable
    {
        public string BirthDate { get; private set; }
        public int Age { get; private set; }
        public string Name { get; private set; }

        public Citizen(string id, string birthDate, string name, int age) : base(id)
        {
            this.BirthDate = birthDate;
            this.Name = name;
            this.Age = age;
        }
    }
}
