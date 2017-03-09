
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
using MiNET.Plugins.Attributes;

namespace Essentials.Command
{
    public class Popular
    {
        private Essentials Plugin;

        public Popular(Essentials plugin)
        {
            Plugin = plugin;
        }
        
        [Command(Name = "popular", Description = "Vote other player.")]
        public void Execute(Player sender)
        {
            if(Plugin.GetPopular(sender.Username))
            {
                sender.SendMessage("Your popular count: " + Plugin.GetPopular(sender.Username));
            }
        }

        [Command(Name = "popular", Description = "Vote other player.")]
        public void Execute(Player sender, string player)
        {
            if(Plugin.GetPopular(player))
            {
                sender.SendMessage("Voted to " + player + ".");
            }
        }
    }
}
