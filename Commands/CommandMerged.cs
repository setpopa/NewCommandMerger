using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using System;
using Rocket.Core;
using NewCommandMerger.RegistrationComponents;
using OpenMod.API.Commands;
using OpenMod.Core.Helpers;
using Rocket.Unturned.Player;

namespace NewCommandMerger.Commands
{
    internal class CommandMerged : UnturnedCommand
    {
        private readonly ICommandExecutor m_commandExecutor;
        private readonly CommandMergedData _commandMergedData;
        public CommandMerged(CommandMergedData commandMergedData, ICommandExecutor commandExecutor, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _commandMergedData = commandMergedData;
            m_commandExecutor = commandExecutor;
        }

        protected override async UniTask OnExecuteAsync()
        {
            var user = (UnturnedUser)Context.Actor;

            await UniTask.SwitchToMainThread();
            
            foreach (string rmCommand in _commandMergedData.RocketModCommands)
            {
               R.Commands.Execute(UnturnedPlayer.FromPlayer(user.Player.Player), rmCommand);
            }
            foreach (string omCommand in _commandMergedData.OpenModCommands)
            {
                await m_commandExecutor.ExecuteAsync(Context.Actor, ArgumentsParser.ParseArguments(omCommand), "");
            }

        }
    }
}
