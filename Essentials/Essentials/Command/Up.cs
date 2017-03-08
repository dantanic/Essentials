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
    public class Up
    {
        private Essentials Plugin;

        public Up(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "up")]
        public void Execute(Player sender, int y)
        {
            var kp = sender.KnownPosition;
            var pos = new PlayerLocation()
            {
                X = kp.X,
                Y = kp.Y,
                Z = kp.Z
            };
            var py = y + pos.Y;

            sender.Teleport(new PlayerLocation()
            {
                X = kp.X,
                Y = py,
                Z = kp.Z
            });
        }
    }
}
