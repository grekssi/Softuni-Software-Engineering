﻿using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles.Models
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private double cubicCentimeters;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
            
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
            private set => this.cubicCentimeters = value;
        }
        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
