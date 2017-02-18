
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
using System.Linq;
using System.Collections.Generic;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiOP;
using Essentials.Resources;

namespace Essentials.Command
{
    public class KickCommand
    {
        private Essentials Plugin { get; set; }
        public KickCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void kick(Player sender, string targetname)
        {
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            target.Disconnect(StringResources.Kick_DisconnectMessage);
            sender.SendMessage(StringResources.Kick_CompleteMessage.Replace("{{target}}", targetname));
        }
        [Command]
        public void kick(Player sender, string targetname, string msg)
        {
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            target.Disconnect($"{StringResources.Kick_DisconnectMessage } : {msg}");
            sender.SendMessage(StringResources.Kick_CompleteMessage.Replace("{{target}}", targetname));
        }
    }
}
