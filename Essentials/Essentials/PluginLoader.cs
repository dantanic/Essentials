
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
using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using Essentials.Resources;
using Newtonsoft.Json;
using Essentials.Command;
using MiNET.Utils;
using Essentials.Permission;
using System.Text;
using Essentials.Util;

namespace Essentials
{
    [Plugin(PluginName = "Essentials", Description = "에센셜 플러그인", PluginVersion = "1.0", Author = "PIEA Organization")]
    public class PluginLoader : Plugin
    {
        
        protected override void OnEnable()
        {
            SetUserLanguage();
            RegisterCommands();
            CreateFiles();
            Console.WriteLine(ContextConstants.PrefixNoColor + StringResources.Essential_PluginOnEnabled);

            Context.Server.PlayerFactory.PlayerCreated += (sender, args) =>
            {
                Player player = args.Player;
                player.PlayerJoin += new Handler().PlayerJoin;
                player.PlayerLeave += new Handler().PlayerLeave;
            };
        }

        private void CreateFiles()
        {
            var homePath = IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.HomeFile);
            if (!File.Exists(homePath))
            {
                File.Create(homePath);
            }

            var banPath = ContextConstants.BanFile;
            if (!File.Exists(banPath))
            {
                File.Create(banPath);
            }

            var permPath = IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.PermFile);
            if (!File.Exists(permPath))
            {
                var json = JsonConvert.SerializeObject(new CommandPermission()
                {
                    gamemode = Permissions.OP,
                    gm = Permissions.OP,
                    heal = Permissions.OP,
                    tp = Permissions.OP,
                    kick = Permissions.OP,
                    kill = Permissions.OP,
                    ban = Permissions.ADMIN,
                    m = Permissions.USER,
                    t = Permissions.USER,
                    w = Permissions.USER,
                    tpa = Permissions.USER,
                    tpaccept = Permissions.USER,
                    tpdeny = Permissions.USER,
                }, Formatting.Indented);

                File.WriteAllText(permPath, json, Encoding.UTF8);
            }
        }

        private void RegisterCommands()
        {
            Essentials plugin = new Essentials();

            Context.PluginManager.LoadCommands(new GamemodeCommand(plugin));
            Context.PluginManager.LoadCommands(new TellCommand(plugin));
            Context.PluginManager.LoadCommands(new TpCommand(plugin));
            Context.PluginManager.LoadCommands(new KillCommand(plugin));
            Context.PluginManager.LoadCommands(new KickCommand(plugin));
            Context.PluginManager.LoadCommands(new BanCommand(plugin));
            //Context.PluginManager.LoadCommands(new HomeCommand(plugin));
        }

        private void SetUserLanguage()
        {
            var culture = Config.GetProperty("lang", "en-US");
            ResourceManager.SetLanguage(culture);
        }
    }
}
