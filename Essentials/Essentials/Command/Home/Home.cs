
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
using MiNET.Utils;

namespace Essentials.Command.Home
{
    public class Home
    {
        private Essentials Plugin;

        public Home(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "home", Description = "Teleport to your home position.")]
        public void Execute(Player sender)
        {
            if(Plugin.GetHome(sender) != null)
            {
                PlayerLocation pos = Plugin.GetHome(sender);

                sender.Teleport(pos);
                sender.SendMessage(ChatColors.Green + "Teleporting...");
            }
        }
    }
}
