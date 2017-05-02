using System.Reflection;

namespace King.Environment.Commands
{
    public class CommandDescriptor
    {
        public string[] Names { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public string HelpText { get; set; }
    }
}