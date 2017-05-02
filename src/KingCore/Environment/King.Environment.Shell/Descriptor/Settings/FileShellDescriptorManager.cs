﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using King.Environment.Shell.Descriptor.Models;

namespace King.Environment.Shell.Descriptor.Settings
{
    /// <summary>
    /// Implements <see cref="IShellDescriptorManager"/> by returning the features from a configuration file.
    /// </summary>
    public class FileShellDescriptorManager : IShellDescriptorManager
    {
        private readonly ShellSettingsWithTenants _shellSettings;
        private ShellDescriptor _shellDescriptor;

        public FileShellDescriptorManager(ShellSettings shellSettings)
        {
            _shellSettings = shellSettings as ShellSettingsWithTenants;

            if (_shellSettings == null)
            {
                throw new ArgumentException(nameof(shellSettings));
            }
        }

        public Task<ShellDescriptor> GetShellDescriptorAsync()
        {
            if (_shellDescriptor == null)
            {
                _shellDescriptor = new ShellDescriptor
                {
                    Features = _shellSettings.Features.Select(x => new ShellFeature(x)).ToList()
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
