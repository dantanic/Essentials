
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
using System.Collections.Generic;
using Essentials.Util;

namespace Essentials
{
    public class PluginLoader : Essentials
    {
        public static List<string> banlist = new List<string>();
        protected override void OnEnable()
        {
            SetUserLanguage();
            // RegisterCommands();
            CreateFiles();
            ReadFile();
            Console.WriteLine(ContextConstants.PrefixNoColor + StringResources.Essential_PluginOnEnabled);
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
        /*
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
        */
        private void ReadFile()
        {
            using (StreamReader reader = new StreamReader("banlist.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    banlist.Add(line);
                }
            }
        }

        private void SetUserLanguage()
        {
            var culture = Config.GetProperty("lang", "en-US");
            ResourceManager.SetLanguage(culture);
        }
    }
}
