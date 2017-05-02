using King.Environment.Extensions.Features;
using King.Environment.Shell.Descriptor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace King.Environment.Shell
{
    public delegate void FeatureDependencyNotificationHandler(string messageFormat, IFeatureInfo feature, IEnumerable<IFeatureInfo> features);

    public interface IShellDescriptorFeaturesManager
    {
        Task<IEnumerable<IFeatureInfo>> EnableFeaturesAsync(
            ShellDescriptor shellDescriptor, IEnumerable<IFeatureInfo> features);
        Task<IEnumerable<IFeatureInfo>> EnableFeaturesAsync(
            ShellDescriptor shellDescriptor, IEnumerable<IFeatureInfo> features, bool force);
        Task<IEnumerable<IFeatureInfo>> DisableFeaturesAsync(
            ShellDescriptor shellDescriptor, IEnumerable<IFeatureInfo> features);
        Task<IEnumerable<IFeatureInfo>> DisableFeaturesAsync(
            ShellDescriptor shellDescriptor, IEnumerable<IFeatureInfo> features, bool force);
    }
}
