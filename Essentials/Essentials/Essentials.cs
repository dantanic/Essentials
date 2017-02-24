
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
using System.Collections.Generic;
using System;
using System.IO;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using Essentials.Resources;
using Newtonsoft.Json;
using Essentials.Command;
using MiNET.Utils;
using Essentials.Permission;
using System.Text;
using Essentials.Util;
using Newtonsoft.Json.Linq;
using MiOP;

namespace Essentials
{
    [Plugin(PluginName = "Essentials", Description = "에센셜 플러그인", PluginVersion = "1.0", Author = "PIEA Organization")]
    public class Essentials : Plugin
    {
        private List<string> AFKList = new List<string>();

        public void SetAFK(Player player)
        {
            AFKList.Add(player.Username);
        }

        public void RemoveAFK(Player player)
        {
            AFKList.Remove(player.Username);
        }

        public bool IsAFK(Player player)
        {
            return AFKList.Contains(player.Username);
        }

        public static bool VerifyPermission(Player sender, string cmd)
        {
            JObject permi = JObject.Parse(File.ReadAllText
                (IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.PermFile), Encoding.UTF8));

            var verify = true;
            if (permi[cmd].ToString() == "OP")
            {
                if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
                {
                    sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Essentials_NoMatchPermission}");
                    verify = false;
                }
            }
            else if (permi[cmd].ToString() == "ADMIN")
            {
                if (!PermissionManager.Manager.IsAdmin(sender.Username))
                {
                    sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Essentials_NoMatchPermission}");
                    verify = false;
                }
            }

            return verify;
        }
        class permclass
        {
            
        }
    }
}
