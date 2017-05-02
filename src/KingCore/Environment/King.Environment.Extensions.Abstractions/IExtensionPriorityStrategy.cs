using King.Environment.Extensions.Features;

namespace King.Environment.Extensions
{
    public interface IExtensionPriorityStrategy
    {
        int GetPriority(IFeatureInfo feature);
    }
}
