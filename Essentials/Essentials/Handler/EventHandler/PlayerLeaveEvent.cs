using Essentials.Resources;
using MiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials.Handler.EventHandler
{
    public class PlayerLeaveEvent : BaseEventHandler
    {
        public void PlayerLeave(object sender, PlayerEventArgs e)
        {
            var pl = e.Player;
            var name = pl.Username;
            if (pl == null) throw new NotImplementedException();
            pl.Level.BroadcastMessage($"§e{StringResources.JoinMessage.Replace("{{player}}", name)}");
        }
    }
}
