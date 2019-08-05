using System;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles.Models;

namespace MXGP
{
    using Models.Motorcycles;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
