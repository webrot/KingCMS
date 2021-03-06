﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using King.Environment.Shell;

namespace King.Data.Migration
{
    /// <summary>
    /// Registers to KingShell.Activated in order to run migrations automatically
    /// </summary>
    public class AutomaticDataMigrations : IModularTenantEvents
    {
        private readonly ShellSettings _shellSettings;
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public AutomaticDataMigrations(
            IServiceProvider serviceProvider,
            ShellSettings shellSettings,
            ILogger<AutomaticDataMigrations> logger)
        {
            _serviceProvider = serviceProvider;
            _shellSettings = shellSettings;
            _logger = logger;
        }

        public Task ActivatedAsync()
        {
            if (_shellSettings.State != Environment.Shell.Models.TenantState.Uninitialized)
            {
                var dataMigrationManager = _serviceProvider.GetService<IDataMigrationManager>();
                return dataMigrationManager.UpdateAllFeaturesAsync();
            }

            return Task.CompletedTask;
        }

        public Task ActivatingAsync()
        {
            return Task.CompletedTask;
        }

        public Task TerminatingAsync()
        {
            return Task.CompletedTask;
        }

        public Task TerminatedAsync()
        {
            return Task.CompletedTask;
        }
    }
}