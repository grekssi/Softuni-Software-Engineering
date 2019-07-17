using System.Reflection.Metadata.Ecma335;

namespace MilitaryElite2.Interfaces
{
    public interface ISoldier
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
