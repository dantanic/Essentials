
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
using Essentials.Resources;
using Essentials.Util;

namespace Essentials.Command
{
    public class KillCommand : BaseCommand
    {
        [Command]
        public void kill(Player sender)
        {
            if (!VerifyPermission(sender, "kill"))
            {
                return;
            }
            sender.HealthManager.Kill();
        }
        [Command]
        public void kill(Player sender, string targetname)
        {
            if (!VerifyPermission(sender, "kill"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            target.HealthManager.Kill();
            target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Kill_DisplayMessage.Replace("{{killer}}", sender.Username)}");
        }
    }
}
