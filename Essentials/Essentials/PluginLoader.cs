
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

using Essentials.Permission;
using Essentials.Resources;
using Essentials.Util;
using MiNET.Utils;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Essentials
{
    public class PluginLoader : Essentials
    {
        protected override void OnEnable()
        {
            SetUserLanguage();
            CreateFiles();

            Console.WriteLine(Prefix + StringResources.Essential_PluginOnEnabled);
        }

        private void CreateFiles()
        {
            var permPath = IO.GetFilePath("Essentials", "permissions.json");
            if (!File.Exists(permPath))
            {
                var json = JsonConvert.SerializeObject(new CommandPermission()
                {
                    heal = Permissions.OP,
                    sethome = Permissions.USER,
                    home = Permissions.USER,
                    tpa = Permissions.USER,
                    tpaccept = Permissions.USER,
                    tpdeny = Permissions.USER,
                }, Formatting.Indented);

                File.WriteAllText(permPath, json, Encoding.UTF8);
            }
        }

        private void SetUserLanguage()
        {
            var culture = Config.GetProperty("lang", "en-US");

            LangManager.SetLanguage(culture);
        }
    }
}
