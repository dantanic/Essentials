
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

using Essentials.Resources;
using Essentials.Util;
using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiOP;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace Essentials
{
    [Plugin(PluginName = "Essentials", Description = "에센셜 플러그인", PluginVersion = "1.0", Author = "PIEA Organization")]
    public class Essentials : Plugin
    {

        public const string Prefix = "[Essentials]";

        public static bool VerifyPermission(Player sender, string cmd)
        {
            JObject permi = JObject.Parse(File.ReadAllText
                (IO.GetFilePath("Essentials", "permissions.json"), Encoding.UTF8));

            var verify = true;
            if (permi[cmd].ToString() == "OP")
            {
                if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
                {
                    sender.SendMessage($"{Prefix}{ChatColors.Red}{StringResources.Essentials_NoMatchPermission}");
                    verify = false;
                }
            }
            else if (permi[cmd].ToString() == "ADMIN")
            {
                if (!PermissionManager.Manager.IsAdmin(sender.Username))
                {
                    sender.SendMessage($"{Prefix}{ChatColors.Red}{StringResources.Essentials_NoMatchPermission}");
                    verify = false;
                }
            }

            return verify;
        }
    }
}
