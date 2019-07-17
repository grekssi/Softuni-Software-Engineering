using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Car
    {
        public string Model { get; private set; }
        public Cargo cargo { get; private set; }
        public Engine engine { get; private set; }
        public Tire tire { get; private set; }

        public Car(string model, Cargo cargo, Engine engine, Tire tire)
        {
            this.Model = model;
            this.cargo = cargo;
            this.engine = engine;
            this.tire = tire;
        }
    }
}
