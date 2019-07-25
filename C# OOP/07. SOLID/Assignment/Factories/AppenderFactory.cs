using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp236.Appenders;
using ConsoleApp236.Layouts;

namespace ConsoleApp236.Factories
{
    class AppenderFactory
    {
        private IAppender appender;

        public IAppender CreateAppender(string type, ILayout layout)
        {
            switch (type)
            {
                case "FileAppender":
                    LogFile logfile = new LogFile();
                    appender = new FileAppender(layout, logfile);
                    break;
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout);
                    break;
            }
            return appender;
        }

        public IAppender CreateAppender(string type, ILayout layout, string treshold)
        {
            switch (type)
            {
                case "FileAppender":
                    LogFile logfile = new LogFile();
                    appender = new FileAppender(layout, logfile, treshold);
                    break;
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, treshold);
                    break;
            }
            return appender;
        }
    }
}
