
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

namespace Essentials.Command
{
    public class AFK
    {
        private Essentials Plugin;

        public AFK(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "afk", Description = "Set afk mode.")]
        public void Execute(Player sender)
        {
            if (!Plugin.GetAFK(sender))
            {
                Plugin.SetAFK(sender);

                sender.SendMessage(ChatColors.Green + sender.Username + " is now afk.");
            }
            else
            {
                Plugin.RemoveAFK(sender);

                sender.SendMessage(ChatColors.Red + sender.Username + " is no longer afk.");
            }
        }
    }
}
