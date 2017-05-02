using System.Collections.Generic;

namespace King.Environment.Commands.Parameters
{
    public interface ICommandParametersParser
    {
        CommandParameters Parse(IEnumerable<string> args);
    }
}