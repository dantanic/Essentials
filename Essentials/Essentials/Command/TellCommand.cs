
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
        public void tell(Player sender, string targetName, string message)
        {
            if (!Essentials.VerifyPermission(sender, "m"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage(ContextConstants.Prefix + "플레이어가 존재하지 않습니다!");
            } else
            {
                var senderm = "[나 -> " + targetName + "]" + message;
                var tgm = "[" + targetName + " -> 나]" + message;
                sender.SendMessage(ContextConstants.Prefix + senderm);
                targetPlayer.SendMessage(ContextConstants.Prefix + tgm);
            }
        }
#region short command
        [Command]
        public void w(Player sender, string targetName, string message)
        {
            tell(sender, targetName, message);
        }
        [Command]
        public void t(Player sender, string targetName, string message)
        {
            tell(sender, targetName, message);
        }
        [Command]
        public void m(Player sender, string targetName, string message)
        {
            tell(sender, targetName, message);
        }
#endregion
    }
}
