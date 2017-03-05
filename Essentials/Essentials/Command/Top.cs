
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
using MiNET.Blocks;
using System.Collections;

namespace Essentials.Command
{
    public class Top
    {
        private Essentials Plugin;
        public Top(Essentials plugin)
        {
            Plugin = plugin;
        }
        [Command(Name = "top")]
        public void excute(Player player)
        {
            int py = 0;
            var pos = player.KnownPosition;
            var px = pos.X;
            var pz = pos.Z;
            Block block = new Block(0);
            for (var fy=0;fy<=256;)
            {
                var fpos = new PlayerLocation()
                {
                    X = px,
                    Y = fy,
                    Z = pz
                };
                var nblock = fpos.GetCoordinates3D();
                block.Coordinates = nblock;
                if (block.Id == 0)
                {
                } else
                {
                    py = fy;
                }
            }
            player.Teleport(new PlayerLocation()
            {
                X = px,
                Y = py,
                Z = pz
            });
        }
    }
}
