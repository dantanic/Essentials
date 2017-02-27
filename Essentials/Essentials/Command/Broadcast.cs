
/*
     ________  ___  _______   ________     
    |\   __  \|\  \|\  ___ \ |\   __  \    
    \ \  \|\  \ \  \ \   __/|\ \  \|\  \   
     \ \   ____\ \  \ \  \_|/_\ \   __  \  
      \ \  \___|\ \  \ \  \_|\ \ \  \ \  \ 
       \ \__\    \ \__\ \_______\ \__\ \__\
        \|__|     \|__|\|_______|\|__|\|__|          
    
    PIEA, The MiNET plugins development organization.         
*/

using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;

namespace Essentials.Command
{
    public class Broadcast
    {
        private Essentials Plugin;

        public Broadcast(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "broadcast", Description = "Broadcast messages.")]
        public void Execute(Player sender, params string[] text)
        {
            string message = Plugin.GetMessage(text);

            sender.SendMessage(ChatColors.LightPurple + "[Server] " + message);
        }
    }
}