using Essentials.Resources;
using MiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials.Handler.EventHandler
{
    public class PlayerJoinEvent : BaseEventHandler
    {
        public void PlayerJoin(object sender, PlayerEventArgs e)
        {
            var pl = e.Player;
            var name = pl.Username;
            if (pl == null) throw new NotImplementedException();
            foreach (var item in PluginLoader.banlist)
            {
                if (item == name)
                {
                    pl.Disconnect(StringResources.Ban_DisMsg);
                }
            }
            pl.Level.BroadcastMessage($"§e{StringResources.JoinMessage.Replace("{{player}}", name)}");
            Console.WriteLine($"{StringResources.JoinMessage.Replace("{{player}}", name)}");
        }
    }
}
