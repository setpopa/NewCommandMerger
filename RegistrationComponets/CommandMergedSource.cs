using OpenMod.API.Commands;
using System.Collections.Generic;
using NewCommandMerger.API;
using System.Threading.Tasks;

namespace NewCommandMerger.RegistrationComponents
{
    internal class CommandMergedSource : ICommandSource
    {
        private readonly ICommandSourceController _commandSourceController;
        public CommandMergedSource(ICommandSourceController commandSourceController)
        {
            _commandSourceController = commandSourceController;
        }
        public Task<IReadOnlyCollection<ICommandRegistration>> GetCommandsAsync()
        {
            return _commandSourceController.GetCommandsAsync();
        }
    }
}
