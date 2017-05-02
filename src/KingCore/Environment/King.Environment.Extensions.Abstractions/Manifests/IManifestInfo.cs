using Microsoft.Extensions.Configuration;

namespace King.Environment.Extensions
{
    public interface IManifestInfo
    {
        bool Exists { get; }
        string Name { get; }
        string Description { get; }
        string Type { get; }
        IConfigurationRoot ConfigurationRoot { get; }
    }
}