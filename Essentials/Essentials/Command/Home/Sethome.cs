﻿
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

namespace Essentials.Command.Home
{
    public class SetHome
    {
        private Essentials Plugin;

        public SetHome(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "sethome", Description = "Set your home position.")]
        public void Execute(Player sender)
        {
            Plugin.SetHome(sender, sender.KnownPosition);

            sender.SendMessage(ChatColors.Yellow + "Home set.");
        }
    }
}
