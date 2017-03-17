using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiOP;

namespace Essentials.Command
{
    public class Notice
    {
        private Essentials Plugin;

        public Notice(Essentials plugin)
        {
            Plugin = plugin;
        }
        [Command(Name = "notice")]
        public void Execute(Player sender, string msg)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender)) return;
            Plugin.serbroadcast($"{ChatColors.Red}[공지]{ChatColors.White}{msg}");
        }
    }
}
