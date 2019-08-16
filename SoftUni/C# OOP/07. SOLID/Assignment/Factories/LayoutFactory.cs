using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp236.Layouts;

namespace ConsoleApp236.Factories
{
    public class LayoutFactory
    {
        private ILayout layout;

        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
            }
            return layout;
        }
    }
}
