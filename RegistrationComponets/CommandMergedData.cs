
using UnityEngine.Android;

namespace NewCommandMerger.RegistrationComponents
{
    internal class CommandMergedData
    {
        public string[] RocketModCommands { get; set; }

        public string[] OpenModCommands { get; set; }
        public CommandMergedData() {
            
            RocketModCommands = new string[] {};
            OpenModCommands = new string[] { };
        }
    }
}
