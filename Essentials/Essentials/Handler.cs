
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
            using (StreamReader reader = new StreamReader(IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.BanFile)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == e.Player.Username)
                    {
                        e.Player.Disconnect(StringResources.Ban_DisconnectMsg);
                        return;
                    }
                }
            var pl = e.Player;
            var name = pl.Username;
            if(pl == null) throw new NotImplementedException();
            pl.Level.BroadcastMessage($"§e{name}joined the game");
            //pl.Level.BroadcastMessage($"§e{name}님이 게임에 참여했습니다");
            }
        }
    }
}

