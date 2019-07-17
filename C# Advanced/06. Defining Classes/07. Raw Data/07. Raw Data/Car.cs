using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using _07._Raw_Data;

namespace _07._Raw_Data
{
    public class Car
    {
        private Tire1 tire1;
        private Tire2 tire2;
        private Tire3 tire3;
        private Tire4 tire4;
        private Engine engine;
        private Cargo cargo;
        private string model;

        public Engine Engine
        {
            get { return this.engine; }
            private set { this.engine = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public Cargo Cargo
        {
            get { return this.cargo; }
            private set { this.cargo = value; }
        }

        public Tire1 Tire1
        {
            get { return this.tire1; }
            set { this.tire1 = value; }
        }
        public Tire2 Tire2
        {
            get { return this.tire2; }
            set { this.tire2 = value; }
        }
        public Tire3 Tire3
        {
            get { return this.tire3; }
            set { this.tire3 = value; }
        }
        public Tire4 Tire4
        {
            get { return this.tire4; }
            set { this.tire4 = value; }
        }
        public Car(string model, Engine engine, Cargo cargo, Tire1 tire1, Tire2 tire2, Tire3 tire3, Tire4 tire4)
        {
            this.Tire1 = tire1;
            this.Tire2 = tire2;
            this.Tire3 = tire3;
            this.Tire4 = tire4;
            
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }
    }
}
