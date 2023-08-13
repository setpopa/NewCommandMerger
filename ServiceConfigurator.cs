using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Ioc;
using OpenMod.Core.Commands;
using NewCommandMerger.RegistrationComponents;

namespace NewCommandMerger
{
    internal class ServiceConfigurator : IServiceConfigurator
    {
        public void ConfigureServices(IOpenModServiceConfigurationContext openModStartupContext, IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<CommandStoreOptions>(
                options => options.AddCommandSource<CommandMergedSource>());
        }
    }
}
