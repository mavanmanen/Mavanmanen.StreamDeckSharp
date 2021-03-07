using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp.Attributes;
using Mavanmanen.StreamDeckSharp.Internal;
using Mavanmanen.StreamDeckSharp.Internal.Events.ActionEvents;
using Mavanmanen.StreamDeckSharp.Internal.Events.PluginEvents;
using Mavanmanen.StreamDeckSharp.Internal.Manifest;
using Microsoft.Extensions.DependencyInjection;

namespace Mavanmanen.StreamDeckSharp
{
    public class StreamDeckClient
    {
        private readonly InternalClient? _client;
        private readonly ServiceProvider _services;

        public StreamDeckClient(string[] args)
        {
            var services = new ServiceCollection();

            RegisterPlugin(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            RegisterPluginServices(services, serviceProvider);
            RegisterActions(services);

            services.AddSingleton(this);
            services.AddSingleton<ActionEventHandler>();
            services.AddSingleton<PluginEventHandler>();
            services.AddSingleton<ManifestGenerator>();

            _services = services.BuildServiceProvider();

            if (!args.Any())
            {
                var manifestGenerator = _services.GetRequiredService<ManifestGenerator>();
                manifestGenerator.GenerateManifest();

                return;
            }

            _client = new InternalClient(args);
            _client.ActionEventReceived += HandleActionEventAsync;
            _client.PluginEventReceived += HandlePluginEventAsync;
        }

        public async Task RunAsync()
        {
            if (_client == null)
            {
                return;
            }

            await _client.RunAsync();
        }

        private static void RegisterActions(IServiceCollection services)
        {
            List<ActionDefinition> actions = Assembly.GetEntryAssembly()!.GetTypes()
                .Where(t => t.GetCustomAttribute<StreamDeckActionAttribute>() != null)
                .Select(t => new ActionDefinition(t))
                .ToList();

            services.AddSingleton(actions);
            foreach (var action in actions)
            {
                services.AddScoped(action.Type, action.Type);
            }
        }

        private static void RegisterPlugin(IServiceCollection services)
        {
            Type? pluginType = Assembly.GetEntryAssembly()!.GetTypes()
                .FirstOrDefault(t => t.GetCustomAttribute<StreamDeckPluginAttribute>() != null);

            if (pluginType == null)
            {
                throw new ApplicationException("Plugin not found.");
            }

            var pluginDefinition = new PluginDefinition(pluginType);
            services.AddSingleton(pluginDefinition);
            services.AddScoped(typeof(StreamDeckPlugin), pluginDefinition.Type);
        }

        private static void RegisterPluginServices(IServiceCollection services, IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            StreamDeckPlugin plugin = scope.ServiceProvider.GetRequiredService<StreamDeckPlugin>();
            plugin.RegisterServices(services);
        }

        private async void HandleActionEventAsync(object? _, StreamDeckActionEvent e)
        {
            var handler = _services.GetRequiredService<ActionEventHandler>();
            await handler.HandleEventAsync(e);
        }

        private async void HandlePluginEventAsync(object? _, StreamDeckPluginEvent e)
        {
            var handler = _services.GetRequiredService<PluginEventHandler>();
            await handler.HandleEventAsync(e);
        }
    }
}