using System;
using System.Collections.Generic;
using System.Linq;

namespace King.Environment.Commands
{
    [AttributeUsage(AttributeTargets.Method)]
    public class KingSwitchesAttribute : Attribute
    {
        private readonly string _switches;

        public KingSwitchesAttribute(string switches)
        {
            _switches = switches;
        }

        public IEnumerable<string> Switches
        {
            get
            {
                return (_switches ?? "").Trim().Split(',').Select(s => s.Trim());
            }
        }
    }
}