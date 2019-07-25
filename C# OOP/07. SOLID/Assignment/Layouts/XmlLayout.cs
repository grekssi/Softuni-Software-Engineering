using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp236.Layouts
{
    class XmlLayout : ILayout
    {
        public string DateOfError { get; private set; }
        public string ReportLevel { get; private set; }
        public string ErrorMessage { get; private set; }

        public string CreateMessage()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{this.DateOfError}</date>");
            sb.AppendLine($"    <level>{this.ReportLevel}</level>");
            sb.AppendLine($"    <message>{this.ErrorMessage}</message>");
            sb.AppendLine("</log>");
            return sb.ToString().TrimEnd();
        }

        public void GetStrings(string error, string date, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.DateOfError = date;
            this.ReportLevel = error;
        }
    }
}
