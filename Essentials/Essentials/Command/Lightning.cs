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
            var gp = Plugin.GetPlayer(name);
            if (gp == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다.");
            }
            gp.StrikeLightning();
            sender.SendMessage("lightning!!!");
            gp.SendMessage("lightning!!!");
        }
    }
}
