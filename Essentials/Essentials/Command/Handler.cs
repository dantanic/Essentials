using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essentials;
using MiNET;

namespace Essentials.Command
{
    public class Handler : Essentials
    {
        public void PlayerJoin(object sender, PlayerEventArgs e)
        {
            poplist.Add($"{e.Player.Username},0");
            pjoinFile(e.Player.Username);
            plist.Add(e.Player);
        }
        public void PlayerLeave(object sender, PlayerEventArgs e)
        {
            plist.Remove(e.Player);
        }
    }
}
