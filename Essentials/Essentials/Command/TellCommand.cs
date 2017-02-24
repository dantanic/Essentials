
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
using Essentials.Resources;
using MiNET.Utils;
using Essentials.Util;

namespace Essentials.Command
{
    public class TellCommand : BaseCommand
    {
        [Command]
        public void tell(Player sender, string targetName, string message)
        {
            if (!Essentials.VerifyPermission(sender, "m"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (target == null)
            {
                sender.SendMessage(ContextConstants.Prefix + "플레이어가 존재하지 않습니다!");
            } else
            {
                sender.SendMessage($"{ChatColors.Red}[{StringResources.me} -> {target.Username}] {ChatColors.Gold}{message}");
                target.SendMessage($"{ChatColors.Red}[{target.Username} -> {StringResources.me}] {ChatColors.Gold}{message}");
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
