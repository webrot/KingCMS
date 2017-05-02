using System.Threading.Tasks;

namespace King.Environment.Commands
{
    public interface ICommandHandler
    {
        Task ExecuteAsync(CommandContext context);
    }
}