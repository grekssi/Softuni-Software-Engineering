using System;
using System.Text;

namespace ConsoleApp236.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string DateOfError { get; private set; }
        public string ReportLevel { get; private set; }
        public string ErrorMessage { get; private set; }

        public string CreateMessage()
        {
            return $"{this.DateOfError} - {this.ReportLevel} - {this.ErrorMessage}";
        }

        public void GetStrings(string error, string date, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.DateOfError = date;
            this.ReportLevel = error.ToUpper();
        }
    }
}
