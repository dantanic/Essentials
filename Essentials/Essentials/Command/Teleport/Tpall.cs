using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Plugins.Attributes;
using MiOP;

namespace Essentials.Command.Teleport
{
    public class Tpall
    {
        private Essentials Plugin;

        public Tpall(Essentials plugin)
        {
            Plugin = plugin;
        }
        [Command(Name = "tpall")]
        public void Execute(Player sender)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender)) return;
            Plugin.tpall();
        }
    }
}
