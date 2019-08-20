using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp236
{
    public class LogFile
    {
        private StringBuilder text;

        public LogFile()
        {
            text = new StringBuilder();
        }

        public void Write(string NewLog)
        {
            text.AppendLine(NewLog);
        }

        public double Size()
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text.ToString());
            return asciiBytes.Sum(x => x);
        }
    }
}
