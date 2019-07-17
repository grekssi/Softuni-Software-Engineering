using MilitaryElite2.Interfaces;

namespace MilitaryElite2.Models
{
    public class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value;
        }

        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }

        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
