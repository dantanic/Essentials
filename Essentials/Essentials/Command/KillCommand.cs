
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
    public class KillCommand
    {
        private Essentials Plugin { get; set; }
        public KillCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void kill(Player sender)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }
            sender.HealthManager.Kill();
        }
        [Command]
        public void kill(Player sender, string targetname)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            target.HealthManager.Kill();
            target.SendMessage($"{ChatColors.Red}{sender.Username}{ChatColors.White}님이 당신을 명령어로 죽이셨습니다.");
        }
    }
}
