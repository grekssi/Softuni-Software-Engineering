using System;
using System.Collections.Generic;
using ConsoleApp236.Layouts;

namespace ConsoleApp236.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public string Type { get; set; }
        public ILayout Layout { get; private set; }

        public int SentMessages { get; private set; }
        public LogFile LogFile { get; }

        private int typeResult = 0;

        public ConsoleAppender(ILayout layout, string type)
        {
            this.Layout = layout;
            typeResult = DicThreshold.CheckThreshold(type);
        }

        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
            this.typeResult = 0;
        }

        public void Append(int threshold)
        {
            if (threshold >= typeResult)
            {
                Console.WriteLine(Layout.CreateMessage());
                SentMessages++;
            }
            
        }
    }
}
