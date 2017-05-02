using System.Collections.Generic;

namespace King.Environment.Extensions
{
    public class ExtensionExpanderOptions
    {
        public IList<ExtensionExpanderOption> Options { get; }
            = new List<ExtensionExpanderOption>();
    }

    public class ExtensionExpanderOption
    {
        public string SearchPath { get; set; }
    }
}