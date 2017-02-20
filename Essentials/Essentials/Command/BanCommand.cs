
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

            using (StreamWriter writer = new StreamWriter
                (IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.BanFile), 
                true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(targetname);
            }

            if (target != null)
            {
                target.Disconnect(StringResources.Ban_DisconnectMsg);
            }
            sender.SendMessage(StringResources.Ban_SendMsg.Replace("{{target}}", targetname));
        }
    }
}
