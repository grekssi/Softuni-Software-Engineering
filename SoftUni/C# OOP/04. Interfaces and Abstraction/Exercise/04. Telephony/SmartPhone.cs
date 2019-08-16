using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class SmartPhone : IBrowsing, ICalling
    {
        public string Browse(string website)
        {
            return $"Browsing: {website}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
