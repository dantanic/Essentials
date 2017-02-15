
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
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiOP;

namespace Essentials.Command
{
    public class TpCommand
    {
        private Essentials Plugin { get; set; }
        public TpCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void tp(Player sender, string targetname)
        {
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }
            if (targetPlayer == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            } else
            {
                sender.Teleport(new PlayerLocation()
                {
                    X = targetPlayer.KnownPosition.X,
                    Y = targetPlayer.KnownPosition.Y,
                    Z = targetPlayer.KnownPosition.Z
                });
            }
        }
        [Command]
        public void tp(Player sender, string targetonen, string targettwon)
        {
            var ServerPlayers = sender.Level.Players;
            var targetone = ServerPlayers.ToList().Find(x => x.Value.Username == targetonen).Value;
            var targettwo = ServerPlayers.ToList().Find(x => x.Value.Username == targettwon).Value;
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }
            if (targetone == null || targettwo == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            }
            else
            {
                targetone.Teleport(new PlayerLocation()
                {
                    X = targettwo.KnownPosition.X,
                    Y = targettwo.KnownPosition.Y,
                    Z = targettwo.KnownPosition.Z
                });
                sender.SendMessage("[Essentials] " + targetonen + "님을 " + targettwon + "님에게 티피시켰습니다.");
                targetone.SendMessage("[Essentials] 관리자 " + sender.Username + "님이 당신을 " + targettwon + "님에게 티피시켰습니다.");
                targettwo.SendMessage("[Essentials] 관리자 " + sender.Username + "님이 " + targetonen + "님을 당신에게 티피시켰습니다.");
            }
        }
    }
}
