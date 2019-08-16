using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}
