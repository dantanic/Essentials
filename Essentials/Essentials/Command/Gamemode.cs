
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

using MiNET.Plugins.Attributes;

namespace Essentials.Command
{
    public class Gamemode
    {
        private Essentials Plugin { get; set; }

        public Gamemode(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command]
        public void execute()
        {

        }
    }
}
