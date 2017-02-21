
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
using System.Text;
using MiNET;
using MiNET.Net;
using MiNET.Plugins.Attributes;
using System.IO;
using Essentials.Resources;
using Essentials.Util;

namespace Essentials
{
    public class Handler
    {
        private Essentials Plugin = new Essentials();

        [PacketHandler]
        public void MessagePacket(McpeText packet, Player player)
        {

        }

        public void PlayerJoin(object sender, PlayerEventArgs e)
        {
            var file = IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.BanFile);
            /* if (line == e.Player.Username)
             {
                 e.Player.Disconnect(StringResources.Ban_DisconnectMsg);
                 return;
             }
             */
            e.Player.SendMessage(file);
            var pl = e.Player;
            var name = pl.Username;
            if (pl == null) throw new NotImplementedException();
            pl.Level.BroadcastMessage($"§e{StringResources.JoinMessage.Replace("{{player}}", name)}");
            Console.WriteLine($"{StringResources.JoinMessage.Replace("{{player}}", name)}");
        }
        public void PlayerLeave(object sender, PlayerEventArgs e)
        {
            var pl = e.Player;
            var name = pl.Username;
            if (pl == null) throw new NotImplementedException();
            pl.Level.BroadcastMessage($"§e{StringResources.JoinMessage.Replace("{{player}}", name)}");
        }
    }
}

