
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
            int hgy = 0;
            var k = sender.KnownPosition;
            for(int i = (int) sender.KnownPosition.Y; i <= 256; i++)
            {
                if (sender.Level.GetBlock(sender.KnownPosition.GetCoordinates3D()).Id != 0)
                {
                    hgy = i;
                }
            }
            sender.Teleport(new PlayerLocation()
            {
                X = k.X,
                Y = hgy,
                Z = k.Z
            });
        }
    }
}
