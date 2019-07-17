using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ConsoleApp1
{
    public class Child : Person
    { 
        public Child(int age, string name)
            : base(age, name)
        {
        }
    }
}
