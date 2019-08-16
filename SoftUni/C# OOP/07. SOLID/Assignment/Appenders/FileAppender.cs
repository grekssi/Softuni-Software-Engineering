using System;
using System.IO;
using System.Reflection;
using System.Text;
using ConsoleApp236.Layouts;

namespace ConsoleApp236.Appenders
{
    public class FileAppender :IAppender
    {
        public string Type { get; }
        public ILayout Layout { get; private set; }
        public LogFile LogFile { get; private set; }
        public int SentMessages { get; private set; }

        private int typeResult = 0;
        public FileAppender(ILayout layout, LogFile logFile, string type)
                    :this(layout, logFile)
        {
            this.Type = type;
        }

        public FileAppender(ILayout layout, LogFile logFile)
        : this(layout)
        {
            this.LogFile = logFile;
            this.typeResult = 0;
        }

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
            this.typeResult = 0;
        }

        public void Append(int threshold)
        {
            if (threshold >= typeResult)
            {
                SentMessages++;
                var sb = new StringBuilder();
                sb.AppendLine(Layout.CreateMessage());
                string path = @"C:\Users\bedob\source\repos\ConsoleApp236\ConsoleApp236\bin\Debug\file.txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                TextWriter writer = new StreamWriter(path, true);
                writer.WriteLine(sb.ToString().TrimEnd());
                writer.Close();
                LogFile.Write(sb.ToString().TrimEnd());
            }
            
        }

        
    }
}
