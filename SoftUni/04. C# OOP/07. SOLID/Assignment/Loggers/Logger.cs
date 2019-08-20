using System.Runtime.CompilerServices;
using ConsoleApp236.Appenders;
using ConsoleApp236.Layouts;

namespace ConsoleApp236.Loggers
{
    public class Logger
    {
        private IAppender[] Appenders { get; set; }

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public void Error(string date, string errorMessage)
        {
            LogFiles("error", date, errorMessage);
        }

        public void Info(string date, string errorMessage)
        {
            LogFiles("info", date, errorMessage);
        }

        public void Warning(string date, string errorMessage)
        {
            LogFiles("warning", date, errorMessage);
        }

        public void Critical(string date, string errorMessage)
        {
            LogFiles("critical", date, errorMessage);
        }

        public void Fatal(string date, string errorMessage)
        {
            LogFiles("fatal", date, errorMessage);
        }

        public void LogFiles(string error, string date, string errorMessage)
        {
            foreach (var appender in Appenders)
            {
                appender.Layout.GetStrings(error,
                    date, errorMessage);
                int errorTreshold = DicThreshold.CheckThreshold(error);
                appender.Append(errorTreshold);
            }
        }
    }
}
