
namespace NewCommandMerger.Config
{
    public class CommandMergerConfig
    {
        public string CommandName { get; set; }
        public string[] RocketModCommands { get; set; }
        public string[] OpenModCommands { get; set; }

        public CommandMergerConfig()
        {
            CommandName = "";
            RocketModCommands = new string[0];
            OpenModCommands = new string[0];
        }

    }
}


