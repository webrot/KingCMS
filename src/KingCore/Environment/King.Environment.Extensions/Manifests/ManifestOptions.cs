using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace King.Environment.Extensions
{
    public class ManifestOptions 
    {
        public IList<ManifestOption> ManifestConfigurations { get; }
            = new List<ManifestOption>();
    }
}