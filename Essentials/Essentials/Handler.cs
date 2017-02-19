
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

using MiNET;
using MiNET.Net;
using MiNET.Plugins.Attributes;
using System.IO;
using Essentials.Resources;

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
            StreamReader reader = new StreamReader("banlist.txt");
            string line;
            while((line = reader.ReadLine()) != null)
            {
                if(line == e.Player.Username)
                {
                    e.Player.Disconnect(StringResources.Ban_DisconnectMsg);
                }
            }
        }
    }
}
