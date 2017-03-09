
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
using MiNET.Blocks;
using MiNET.Plugins.Attributes;
using MiNET.Utils;

namespace Essentials.Command
{
    public class Top
    {
        private Essentials Plugin;

        public Top(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "top", Description = "Teleport to your highground block.")]
        public void Execute(Player sender)
        {
            for(int i = 0; i <= 256; i++)
            {
                Block highground = new Block(0);
                highground.Coordinates = sender.KnownPosition.GetCoordinates3D();

                if (highground.Id != 0) sender.Teleport(new PlayerLocation()
                {
                    Y = i
                });
            }
        }
    }
}
