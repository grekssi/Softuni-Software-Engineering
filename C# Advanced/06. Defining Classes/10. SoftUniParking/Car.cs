﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string licensePlate)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = licensePlate;
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            set { this.registrationNumber = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");
            return sb.ToString().Trim();
        }
    }
}
