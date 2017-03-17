using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;

namespace Essentials.Command
{
    public class list
    {
        private Essentials Plugin;

        public list(Essentials plugin)
        {
            Plugin = plugin;
        }
        [Command(Name = "list")]
        public void Execute(Player sender)
        {
            var msg = "";
            foreach (var i in Plugin.plist())
            {
                msg += i.Username+",";
            }
            sender.SendMessage("플레이어 목록 :");
            sender.SendMessage(msg);
        }
    }
}
