using King.Environment.Shell.Builders.Models;
using System;

namespace King.Environment.Shell.Builders
{
    public interface IShellContainerFactory
    {
        IServiceProvider CreateContainer(ShellSettings settings, ShellBlueprint blueprint);
    }
}