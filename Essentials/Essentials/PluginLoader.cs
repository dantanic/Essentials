
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

using System;
using System.IO;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using Essentials.Resources;

using Essentials.Command;
using MiNET.Utils;

namespace Essentials
{
    [Plugin(PluginName = "Essentials", Description = "에센셜 플러그인", PluginVersion = "1.0", Author = "PIEA Organization")]
    public class PluginLoader : Plugin
    {
        
        protected override void OnEnable()
        {
            SetUserLanguage();
            RegisterCommands();
            Console.WriteLine("[Essentials] " + StringResources.Essential_PluginOnEnabled);
            if(!Directory.Exists("Essentials"))
            {
                Directory.CreateDirectory("Essentials");
            }
        }

        private void RegisterCommands()
        {
            Essentials plugin = new Essentials();

            Context.PluginManager.LoadCommands(new GamemodeCommand(plugin));
            Context.PluginManager.LoadCommands(new AFKCommand(plugin));
            Context.PluginManager.LoadCommands(new TellCommand(plugin));
            Context.PluginManager.LoadCommands(new TpCommand(plugin));
            Context.PluginManager.LoadCommands(new KillCommand(plugin));
            Context.PluginManager.LoadCommands(new KickCommand(plugin));
        }

        private void SetUserLanguage()
        {
            var culture = Config.GetProperty("culture", "en");
            ResourceManager.SetLanguage(culture);
        }
    }
}
