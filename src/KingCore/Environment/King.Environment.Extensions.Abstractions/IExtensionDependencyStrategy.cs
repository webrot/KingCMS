using King.Environment.Extensions.Features;

namespace King.Environment.Extensions
{
    public interface IExtensionDependencyStrategy
    {
        bool HasDependency(IFeatureInfo observer, IFeatureInfo subject);
    }
}
