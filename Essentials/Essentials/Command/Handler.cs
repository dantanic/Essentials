using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;

namespace Essentials.Command
{
    public class Handler : Essentials
    {
        public void PlayerJoin(object sender, PlayerEventArgs e)
        {
            poplist.Add($"{e.Player.Username},0");
        }
    }
}
