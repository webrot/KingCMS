using King.Environment.Shell.Models;

namespace King.Environment.Shell
{
    public static class ShellHelper
    {
        public const string DefaultShellName = "Default";

        public static ShellSettings BuildDefaultUninitializedShell = new ShellSettings {
            Name = DefaultShellName,
            State = TenantState.Uninitialized };
    }
}