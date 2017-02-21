
/*
     ________  ___  _______   ________     
    |\   __  \|\  \|\  ___ \ |\   __  \    
    \ \  \|\  \ \  \ \   __/|\ \  \|\  \   
     \ \   ____\ \  \ \  \_|/_\ \   __  \  
      \ \  \___|\ \  \ \  \_|\ \ \  \ \  \ 
       \ \__\    \ \__\ \_______\ \__\ \__\xds
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
using System.IO;
using Essentials.Util;

namespace Essentials.Command
{
    public class BanCommand
    {
        List<string> blist = PluginLoader.banlist;
        private Essentials Plugin { get; set; }
        public BanCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void ban(Player sender, string targetname)
        {
            if (!Essentials.VerifyPermission(sender, "ban"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;

            using (StreamWriter writer = new StreamWriter(ContextConstants.BanFile, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(targetname);
                blist.Add(targetname);
            }

            if (target != null)
            {
                target.Disconnect(StringResources.Ban_DisMsg);
            }
            sender.SendMessage(StringResources.Ban_SendMsg.Replace("{{target}}", targetname));
        }
        [Command]
        public void pardon(Player sender, string targetname)
        {
            if (!Essentials.VerifyPermission(sender, "ban"))
            {
                return;
            }
            File.Delete("banlist.txt");
            File.Create("banlist.txt");
            blist.Remove(targetname);
            using (StreamWriter writer = new StreamWriter(ContextConstants.BanFile, false, System.Text.Encoding.UTF8))
            {
                foreach (var item in blist)
                {
                    writer.WriteLine(item);
                }
            }
            sender.Level.BroadcastMessage(StringResources.Ban_PardMsg.Replace("{{target}}", targetname));
        }
    }
}
