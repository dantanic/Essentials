
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Worlds;
using MiNET.Utils;
using MiOP;

namespace Essentials.Command
{
    public class TellCommand
    {
        private Essentials Plugin { get; set; }
        public TellCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void m(Player sender, string targetName, string message)
        {
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }
            if (targetPlayer == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            } else
            {
                var senderm = "[나 -> " + targetName + "]" + message;
                var tgm = "[" + targetName + " -> 나]" + message;
                sender.SendMessage(senderm);
                targetPlayer.SendMessage(tgm);
            }
        }
    }
}
