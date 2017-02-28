
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
    public class Getpos
    {
        private Essentials Plugin;

        public Getpos(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "getpos", Description = "Get your position.")]
        public void Execute(Player sender)
        {
            PlayerLocation pos = sender.KnownPosition;

            sender.SendMessage(ChatColors.Green + $"Your position: X. {pos.X} Y. {pos.Y} Z. {pos.Z}");
        }
    }
}