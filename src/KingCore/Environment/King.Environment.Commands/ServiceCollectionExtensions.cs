using Microsoft.Extensions.DependencyInjection;
using King.Environment.Commands.Builtin;
using King.Environment.Commands.Parameters;

namespace King.Environment.Commands
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ICommandManager, DefaultCommandManager>();
            services.AddScoped<ICommandHandler, HelpCommand>();

            services.AddScoped<ICommandParametersParser, CommandParametersParser>();
            services.AddScoped<ICommandParser, CommandParser>();

            return services;
        }
    }
}