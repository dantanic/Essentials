using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;

namespace Essentials.Command
{
    public class Lightning
    {
        private Essentials Plugin;

        public Lightning(Essentials plugin)
        {
            Plugin = plugin;
        }
        [Command(Name = "lightning")]
        public void Execute(Player sender)
        {
            sender.StrikeLightning();
            sender.SendMessage("lightning!!!");
        }
        [Command(Name = "lightning")]
        public void Execute(Player sender, string name)
        {
            sender.SendMessage("lightning!!!");
        }
    }
}
