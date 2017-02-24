
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
    public class PlayerJoinEvent : BaseEventHandler
    {
        public void PlayerJoin(object sender, PlayerEventArgs e)
        {
            var pl = e.Player;
            var name = pl.Username;
            if (pl == null) throw new NotImplementedException();
            Console.WriteLine($"{StringResources.JoinMessage.Replace("{{player}}", name)}");
        }
    }
}
