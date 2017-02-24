using Essentials.Util;
using MiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials.Handler.EventHandler
{
    public class EventLoader : BaseEventHandler
    {
        protected override void OnEnable()
        {
            Context.Server.PlayerFactory.PlayerCreated += (sender, args) =>
            {
                var file = IO.GetFilePath(ContextConstants.DefaultDir, ContextConstants.BanFile);
                Player player = args.Player;
                player.PlayerJoin += new PlayerJoinEvent().PlayerJoin;
                player.PlayerLeave += new PlayerLeaveEvent().PlayerLeave;
            };
        }
    }
}
