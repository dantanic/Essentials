
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

using MiNET.Plugins;
using MiNET.Plugins.Attributes;

using Essentials.Command;

namespace Essentials
{
    [Plugin(PluginName = "Essentials", Description = "에센셜 플러그인", PluginVersion = "1.0", Author = "PIEA Organization")]
    public class PluginLoader : Plugin
    {
        protected override void OnEnable()
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            Essentials plugin = new Essentials();

            Context.PluginManager.LoadCommands(new Gamemode(plugin));
        }
    }
}