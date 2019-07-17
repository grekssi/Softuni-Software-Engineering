using System.Runtime.InteropServices;
using System.Text;

namespace ExcFerrari
{
    public class Ferrari : ICar
    {
        private const string Model = "488-Spider";
        public string Driver { get; set; }
        
        public string GasPedal()
        {
            return "Gas!";
        }

        public string BreakPedal()
        {
            return "Brakes!";
        }

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Model}/{this.BreakPedal()}/{this.GasPedal()}/{this.Driver}");
            return sb.ToString().TrimEnd();
        }
    }
}
