
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
using System;

namespace Essentials.Handler.EventHandler
{
    public class PlayerLeaveEvent : BaseEventHandler
    {
        public void PlayerLeave(object sender, PlayerEventArgs e)
        {
            var pl = e.Player;
            var name = pl.Username;

            if (pl == null) throw new NotImplementedException();
            pl.Level.BroadcastMessage($"§e{StringResources.JoinMessage.Replace("{{player}}", name)}");
        }
    }
}
