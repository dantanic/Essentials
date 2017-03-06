using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Plugins.Attributes;

namespace Essentials.Command
{
    public class Popular
    {
        private Essentials Plugin;

        public Popular(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "popular")]
        public void Execute(Player sender)
        {
            int rank;
            foreach (var item in Plugin.poplist)
            {
                if (item.Split(',')[0] == sender.Username)
                {
                    sender.SendMessage($"Your Q-score are {item.Split(',')[1]}");
                }
            }
            sender.SendMessage($"My Rank : ");
        }
        [Command(Name = "popular")]
        public void Execute(Player sender, string args)
        {
            if (args == "up")
            {
                Plugin.up(sender.Username);
            }
            if (args == "down")
            {
                Plugin.down(sender.Username);
            }
        }
    }
}
