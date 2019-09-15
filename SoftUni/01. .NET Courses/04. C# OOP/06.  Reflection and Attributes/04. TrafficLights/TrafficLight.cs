using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity
{
    public class TrafficLight
    {
        private enum TrafficLights
        {
            Red = 0,
            Green = 1,
            Yellow = 2
        }
        private TrafficLights color;

        public string Signal
        {
            get { return this.color.ToString(); }
            set { TrafficLights.TryParse(value, out color); }
        }
        public TrafficLight(string signal)
        {
            this.Signal = signal;
        }

        public void ChangeColor()
        {
            var signals = typeof(TrafficLights).GetEnumValues();
            this.color = (TrafficLights)signals.GetValue((int)(color + 1) % signals.Length);
        }

        public override string ToString()
        {
            return this.Signal.ToString();
        }
    }
}
