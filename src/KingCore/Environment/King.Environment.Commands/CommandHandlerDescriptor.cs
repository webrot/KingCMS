using System.Collections.Generic;

namespace King.Environment.Commands
{
    public class CommandHandlerDescriptor
    {
        public IEnumerable<CommandDescriptor> Commands { get; set; }
    }
}