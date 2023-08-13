using OpenMod.API.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewCommandMerger.API;
using OpenMod.API.Prioritization;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Ioc;

namespace NewCommandMerger.RegistrationComponents
{
    [ServiceImplementation(Lifetime = ServiceLifetime.Singleton, Priority = Priority.Lowest)]
    internal class CommandSourceController : ICommandSourceController
    {
        private readonly Lazy<ICommandStore> _commandStore;
        private readonly List<ICommandRegistration> _registrations;

        public CommandSourceController(Lazy<ICommandStore> commandStore)
        {
            _commandStore = commandStore;

            _registrations = new List<ICommandRegistration>();
        }

        public Task AddCommandAsync(ICommandRegistration registration)
        {
            _registrations.Add(registration);

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<ICommandRegistration>> GetCommandsAsync()
        {
            return Task.FromResult((IReadOnlyCollection<ICommandRegistration>)_registrations);
        }

        public Task InvalidateAsync()
        {
            return _commandStore.Value.InvalidateAsync();
        }
    }
}
