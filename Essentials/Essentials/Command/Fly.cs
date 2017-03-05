
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
    public class Fly
    {
        private Essentials Plugin;

        public Fly(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "fly", Description = "Allow flying.")]
        public void Execute(Player sender)
        {
            if (sender.AllowFly == false) 
            {
               sender.AllowFly = true;
               sender.SendMessage(ChatColors.Green + "You can fly.");
            } else {
               sender.AllowFly = false;
               sender.SendMessage(ChatColors.Green + "You can't fly.");
            }
        }
    }
}
