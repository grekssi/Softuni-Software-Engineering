using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using ConsoleApp236.Appenders;
using ConsoleApp236.Factories;
using ConsoleApp236.Layouts;
using ConsoleApp236.Loggers;

namespace ConsoleApp236
{
    class Program
    {
        static void Main(string[] args)
        {
            AppenderFactory appenderFactory = new AppenderFactory();
            LayoutFactory layoutFactory = new LayoutFactory();

            int appenderscount = int.Parse(Console.ReadLine());
            var appenders = new List<IAppender>();
            for (int i = 0; i < appenderscount; i++)
            {
                var appenderInput = Console.ReadLine().Split(' ').ToArray();
                string appenderType = appenderInput[0];
                string layoutType = appenderInput[1];
                try
                {
                    string reportLevel = appenderInput[2].ToLower();
                    int threshold = DicThreshold.CheckThreshold(reportLevel);
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, "info");
                    appenders.Add(appender);
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split('|').ToArray();
                if (command[0] == "END")
                {
                    break;
                }

                string reportLevel = command[0].ToLower();
                string date = command[1];
                string message = command[2];
                
                Logger logger = new Logger(appenders.ToArray());

                switch (reportLevel)
                {
                    case "info":
                        logger.Info(date, message);
                        break;
                    case "warning":
                        logger.Warning(date, message);
                        break;
                    case "error":
                        logger.Error(date, message);
                        break;
                    case "critical":
                        logger.Critical(date, message);
                        break;
                    case "fatal":
                        logger.Fatal(date, message);
                        break;
                }
            }

            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                var sb = new StringBuilder();
                
                Console.Write($"Appender type: {appender.GetType().Name}, Layout type: {appender.Layout.GetType().Name}, Report level: {appender.Layout.ReportLevel}, Messages appended: {appender.SentMessages}");
                if (appender is FileAppender)
                {
                    Console.WriteLine($", File size: {appender.LogFile.Size()}");
                }
                Console.WriteLine();
            }
        }
    }
}
