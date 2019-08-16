using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class Person
    {
        public string name { get; private set; }
        public int age { get; private set; }

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.name}, Age: {this.age}");
            return sb.ToString().TrimEnd();
        }
    }
}
