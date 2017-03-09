
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
    public class Up
    {
        private Essentials Plugin;

        public Up(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "up", Description = "Up your position to height.")]
        public void Execute(Player sender, int height)
        {
            PlayerLocation pos = sender.KnownPosition;

            sender.Teleport(new PlayerLocation()
            {
                X = pos.X,
                Y = pos.Y + height,
                Z = pos.Z
            });
        }
    }
}
