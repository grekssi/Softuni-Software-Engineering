using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp236.Layouts;

namespace ConsoleApp236.Appenders
{
    public interface IAppender
    {

        string Type { get; }
        ILayout Layout { get; }
        void Append(int threshold);

        int SentMessages { get; }
        LogFile LogFile { get; }
    }    
}
