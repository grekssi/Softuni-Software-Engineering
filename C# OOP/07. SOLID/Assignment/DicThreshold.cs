using System.Collections.Generic;

namespace ConsoleApp236
{
    public static class DicThreshold
    {
        private static Dictionary<string, int> Tresholds = new Dictionary<string, int>()
        {
            {"info", 1},
            {"warning", 2},
            {"error", 3},
            {"critical", 4},
            {"fatal", 5}
        };

        public static int CheckThreshold(string errorLevel)
        {
            return Tresholds[errorLevel];
        }
    }
}
