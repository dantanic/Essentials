
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
    public class AFKCommand
    {
        private Essentials Plugin { get; set; }

        public AFKCommand(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "afk")]
        public void execute(Player sender)
        {
            if (!Plugin.IsAFK(sender))
            {
                Plugin.SetAFK(sender);

                sender.SendMessage(sender.Username + " is now afk.");
            }
            else
            {
                Plugin.RemoveAFK(sender);

                sender.SendMessage(sender.Username + " is no longer afk.");
            }
        }
    }
}
