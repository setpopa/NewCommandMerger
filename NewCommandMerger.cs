using System;
using OpenMod.Unturned.Plugins;
using Cysharp.Threading.Tasks;
using NewCommandMerger.API;
using NewCommandMerger.Config;
using NewCommandMerger.RegistrationComponents;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using OpenMod.API.Plugins;
using YamlDotNet.Core.Tokens;

[assembly: PluginMetadata("NewCommandMerger",
    DisplayName = "NewCommandMerger",
    Author = "Huge thanks to SilK I used most of his code",
    Website = "")]
namespace NewCommandMerger
{
    public class NewCommandMerger : OpenModUnturnedPlugin
    {
        private readonly IConfiguration m_configuration;
        private readonly ICommandSourceController m_commandSourceController;
        private readonly ILogger<NewCommandMerger> m_Logger;


        public NewCommandMerger(ICommandSourceController commandSourceController,IConfiguration configuration, ILogger<NewCommandMerger> logger, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_configuration = configuration;
            m_commandSourceController = commandSourceController;
            m_Logger = logger;
        }

        protected override async UniTask OnLoadAsync()
        {           
            var commands = m_configuration.GetSection("commands").Get<CommandMergerConfig[]?>();

            if (commands != null)
            {
                m_Logger.LogInformation("Config loaded!");
                foreach (var config in commands)
                {
                    m_Logger.LogInformation($"Registrating command {config.CommandName}! With {config.RocketModCommands.Length} RocketMod commands. And {config.OpenModCommands.Length} Openmod commands!");
                    await m_commandSourceController.AddCommandAsync(new CommandMergedRegistration(this, config));
                }

                await m_commandSourceController.InvalidateAsync();
            }
            else
            {
                m_Logger.LogWarning("Empty config or something went wrong.");
            }
                       
        }

        protected override UniTask OnUnloadAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}
