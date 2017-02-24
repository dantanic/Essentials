using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Net;

namespace Essentials.Handler.PacketHandler
{
    public class McpeTextPacket : BasePacketHandler
    {
        [PacketHandler]
        public Package HandlePlayerMessage(McpeText packet, Player player)
        {
            return packet;
        }
    }
}
