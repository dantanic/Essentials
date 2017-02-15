
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

using System;

using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;

namespace Essentials
{
    public class BroadcastCommand
    {
        private Essentials Plugin;

        public BroadcastCommand(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "broadcast")]
        public void execute(Player sender, string text)
        {
            string message = String.Join(" ", text);
            sender.Level.BroadcastMessage(ChatColors.LightPurple + "[{sender.Username}] " + message);
        }
    }
}
