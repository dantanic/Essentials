
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
using Essentials.Util;

namespace Essentials.Command
{
    public class KickCommand : BaseCommand
    {
        [Command]
        public void kick(Player sender, string targetname)
        {
            if (!VerifyPermission(sender, "kick"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            target.Disconnect(StringResources.Kick_DisconnectMessage);
            sender.SendMessage(ContextConstants.Prefix + StringResources.Kick_CompleteMessage.Replace("{{target}}", targetname));
        }
        [Command]
        public void kick(Player sender, string targetname, string msg)
        {
            if (!VerifyPermission(sender, "kick"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            target.Disconnect($"{StringResources.Kick_DisconnectMessage } : {msg}");
            sender.SendMessage(ContextConstants.Prefix + StringResources.Kick_CompleteMessage.Replace("{{target}}", targetname));
        }
    }
}
