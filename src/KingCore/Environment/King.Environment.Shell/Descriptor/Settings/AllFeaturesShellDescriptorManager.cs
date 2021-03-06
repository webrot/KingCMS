﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using King.Environment.Extensions;
using King.Environment.Shell.Descriptor.Models;

namespace King.Environment.Shell.Descriptor.Settings
{
    /// <summary>
    /// Implements <see cref="IShellDescriptorManager"/> by returning a single tenant with all the available 
    /// extensions.
    /// </summary>
    public class AllFeaturesShellDescriptorManager : IShellDescriptorManager
    {
        private readonly IExtensionManager _extensionManager;
        private ShellDescriptor _shellDescriptor;

        public AllFeaturesShellDescriptorManager(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        public Task<ShellDescriptor> GetShellDescriptorAsync()
        {
            if (_shellDescriptor == null)
            {
                _shellDescriptor = new ShellDescriptor
                {
                    Features = _extensionManager.GetFeatures().Select(x => new ShellFeature { Id = x.Id }).ToList()
                };
            }

            return Task.FromResult(_shellDescriptor);
        }

        public Task UpdateShellDescriptorAsync(int priorSerialNumber, IEnumerable<ShellFeature> enabledFeatures, IEnumerable<ShellParameter> parameters)
        {
            return Task.CompletedTask;
        }
    }
}