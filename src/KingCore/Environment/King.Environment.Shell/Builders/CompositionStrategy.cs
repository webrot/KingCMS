﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using King.Environment.Extensions;
using King.Environment.Extensions.Features;
using King.Environment.Shell.Builders.Models;
using King.Environment.Shell.Descriptor.Models;

namespace King.Environment.Shell.Builders
{
    public class CompositionStrategy : ICompositionStrategy
    {
        private readonly IExtensionManager _extensionManager;
        private readonly ILogger _logger;
        private readonly ITypeFeatureProvider _typeFeatureProvider;

        public CompositionStrategy(
            IExtensionManager extensionManager,
            ITypeFeatureProvider typeFeatureProvider,
            ILogger<CompositionStrategy> logger)
        {
            _typeFeatureProvider = typeFeatureProvider;
            _extensionManager = extensionManager;
            _logger = logger;
        }

        public async Task<ShellBlueprint> ComposeAsync(ShellSettings settings, ShellDescriptor descriptor)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Composing blueprint");
            }

            var features = await _extensionManager
                .LoadFeaturesAsync(descriptor.Features.Select(x => x.Id).ToArray());

            var entries = new Dictionary<Type, FeatureEntry>();

            foreach (var feature in features)
            {
                foreach (var exportedType in feature.ExportedTypes) {
                    entries.Add(exportedType, feature);
                }
            }

            var result = new ShellBlueprint
            {
                Settings = settings,
                Descriptor = descriptor,
                Dependencies = entries
            };

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Done composing blueprint");
            }
            return result;
        }
    }
}