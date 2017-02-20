﻿
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MiOP;
using System;
using System.IO;
using Essentials.Util;
using Essentials.Permission;
using System.Text;

namespace Essentials
{
    public class Essentials
    {
        private List<string> AFKList = new List<string>();

        public Essentials()
        {

        }

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

        public static void permission(Player sender, string cmd)
        {
            JObject permi = JObject.Parse(File.ReadAllText
                (IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.PermFile), Encoding.UTF8));

            if (permi[cmd].ToString() == "OP")
            {
                if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
                {
                    return;
                }
                return;
            }
            if (permi[cmd].ToString() == "ADMIN")
            {
                if (!PermissionManager.Manager.IsAdmin(sender.Username))
                {
                    return;
                }
                return;
            }
        }
        class permclass
        {
            
        }
    }
}
