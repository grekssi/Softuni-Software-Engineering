using System.Collections.Generic;
using MilitaryElite2.Models;

namespace MilitaryElite2.Interfaces
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}
