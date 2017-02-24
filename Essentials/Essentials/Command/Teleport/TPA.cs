
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

using Essentials.Resources;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Essentials.Command.Teleport
{
    public class TPA : Command
    {
        /*List<string> tpalist = new List<string>();
        [Command]
        public void tpa(Player sender, string targetname)
        {
            if (!VerifyPermission(sender, "tpa"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (target == null)
            {
                sender.SendMessage($"{Prefix}{ChatColors.Red}{StringResources.Tp_NoMatch}");
            } else
            {
                var color = ChatColors.Red;
                tpalist.Add(sender.Username + "," + targetname);

                sender.SendMessage($"{Prefix}{ChatColors.Gold}{StringResources.Tp_S1.Replace("{{target}}", targetname)}");
                target.SendMessage($"{Prefix}{ChatColors.Gold}{StringResources.Tp_T1.Replace("{{sender}}", sender.Username)}");
                target.SendMessage($"{Prefix}{ChatColors.Gold}{StringResources.Tp_T2.Replace("{{color}}", color)}{ChatColors.Gold},");
                target.SendMessage($"{Prefix}{ChatColors.Gold}{StringResources.Tp_T3.Replace("{{color}}", color)}");
                target.SendMessage($"{Prefix}{ChatColors.Gold}{StringResources.Tp_T4}");
            }
        }*/
    }
}
