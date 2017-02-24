
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

namespace Essentials.Handler.EventHandler
{
    public class EventLoader : BaseEventHandler
    {
        protected override void OnEnable()
        {
            Context.Server.PlayerFactory.PlayerCreated += (sender, args) =>
            {
                Player player = args.Player;
                player.PlayerJoin += new PlayerJoinEvent().PlayerJoin;
                player.PlayerLeave += new PlayerLeaveEvent().PlayerLeave;
            };
        }
    }
}
