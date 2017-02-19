
/*
     ________  ___  _______   ________     
    |\   __  \|\  \|\  ___ \ |\   __  \    
    \ \  \|\  \ \  \ \   __/|\ \  \|\  \   
     \ \   ____\ \  \ \  \_|/_\ \   __  \  
      \ \  \___|\ \  \ \  \_|\ \ \  \ \  \ 
       \ \__\    \ \__\ \_______\ \__\ \__\xds
        \|__|     \|__|\|_______|\|__|\|__|          
    
    PIEA, The MiNET plugins development organization.         
*/
/*
using System;
using System.Linq;
using System.Collections.Generic;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiOP;
using Essentials.Resources;
using System.IO;

namespace Essentials.Command
{
    public class HomeCommand
    {
        private Essentials Plugin { get; set; }
        public HomeCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void sethome(Player sender)
        {
            using (StreamWriter writer = new StreamWriter(ContextConstants.HomeFileName, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine($"{sender.Username}.{sender.KnownPosition.X}.{sender.KnownPosition.Y}.{sender.KnownPosition.Z},");
            }
        }
    }
}
*/