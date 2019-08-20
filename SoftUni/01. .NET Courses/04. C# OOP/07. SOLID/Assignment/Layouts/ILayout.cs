using System;

namespace ConsoleApp236.Layouts
{
    public interface ILayout
    {
        string DateOfError { get; }
        string ReportLevel { get; }
        string ErrorMessage { get; }
        string CreateMessage();
        void GetStrings(string error, string date, string errorMessage);
    }
}
