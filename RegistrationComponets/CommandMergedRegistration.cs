using OpenMod.API;
using OpenMod.API.Commands;
using OpenMod.API.Permissions;
using OpenMod.API.Prioritization;
using OpenMod.Core.Ioc;
using OpenMod.Unturned.Users;
using System;
using System.Collections.Generic;
using NewCommandMerger.Config;
using NewCommandMerger.Commands;

namespace NewCommandMerger.RegistrationComponents
{
    internal class CommandMergedRegistration : ICommandRegistration
    {
        private readonly CommandMergedData _commandMergedData;

        public CommandMergedRegistration(IOpenModComponent component, CommandMergerConfig config)
        {
            Component = component;

            Id = $"{component.OpenModComponentId}.{config.CommandName}";
            Name = config.CommandName;
            Description = "";
            Priority = Priority.High;

            _commandMergedData = new CommandMergedData
            {
                RocketModCommands = config.RocketModCommands,
                OpenModCommands = config.OpenModCommands
            };

            IsEnabled = true;

            Description = null;
            Aliases = null;
            PermissionRegistrations = null;
            Syntax = null;
            ParentId = null;
        }

        public IOpenModComponent Component { get; }

        public string Id { get; }

        public string Name { get; }

        public IReadOnlyCollection<string>? Aliases { get; }

        public IReadOnlyCollection<IPermissionRegistration>? PermissionRegistrations { get; }

        public string? Description { get; }

        public string? Syntax { get; }

        public Priority Priority { get; }

        public string? ParentId { get; }

        public bool IsEnabled { get; }

        public ICommand Instantiate(IServiceProvider serviceProvider)
        {
            return ActivatorUtilitiesEx.CreateInstance<CommandMerged>(Component.LifetimeScope, _commandMergedData);
        }

        public bool SupportsActor(ICommandActor actor)
        {
            return actor is UnturnedUser;
        }
    }
}
