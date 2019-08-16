using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Engine
    {
        public int speed { get; private set; }
        public int power { get; private set; }

        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }
    }
}
