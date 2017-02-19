
/*
     ________  ___  _______   ________     
    |\   __  \|\  \|\  ___ \ |\   __  \    
    \ \  \|\  \ \  \ \   __/|\ \  \|\  \   
     \ \   ____\ \  \ \  \_|/_\ \   __  \  
      \ \  \___|\ \  \ \  \_|\ \ \  \ \  \ 
       \ \__\    \ \__\ \_______\ \__\ \__\
        \|__|     \|__|\|_______|\|__|\|__|          
    
    PIEA, The MiNET plugins development organization.         
*/ 

using System;
using System.Linq;
using MiNET;
using MiNET.Plugins.Attributes;

namespace Essentials.Command
{
    public class TellCommand
    {
        private Essentials Plugin { get; set; }
        public TellCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void m(Player sender, string targetName, string message)
        {
            Essentials.permission(sender, "m");
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            } else
            {
                if (!Plugin.IsAFK(targetPlayer))
                {
                    var senderm = "[나 -> " + targetName + "]" + message;
                    var tgm = "[" + targetName + " -> 나]" + message;
                    sender.SendMessage(senderm);
                    targetPlayer.SendMessage(tgm);
                }
                else
                {
                    var senderm = "[나 -> " + targetName + "]" + message;
                    var tgm = "[" + targetName + " -> 나]" + message;
                    sender.SendMessage(senderm);
                    targetPlayer.SendMessage(tgm);
                    sender.SendMessage("[Essentials]상대방이 잠수 상태이므로 응답하지 않을 수 있습니다!");
                }
            }
        }
        [Command]
        public void w(Player sender, string targetName, string message)
        {
            Essentials.permission(sender, "w");
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            }
            else
            {
                if (!Plugin.IsAFK(targetPlayer))
                {
                    var senderm = "[나 -> " + targetName + "]" + message;
                    var tgm = "[" + targetName + " -> 나]" + message;
                    sender.SendMessage(senderm);
                    targetPlayer.SendMessage(tgm);
                }
                else
                {
                    var senderm = "[나 -> " + targetName + "]" + message;
                    var tgm = "[" + targetName + " -> 나]" + message;
                    sender.SendMessage(senderm);
                    targetPlayer.SendMessage(tgm);
                    sender.SendMessage("[Essentials]상대방이 잠수 상태이므로 응답하지 않을 수 있습니다!");
                }
            }
        }
        [Command]
        public void t(Player sender, string targetName, string message)
        {
            Essentials.permission(sender, "t");
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            }
            else
            {
                if (!Plugin.IsAFK(targetPlayer))
                {
                    var senderm = "[나 -> " + targetName + "]" + message;
                    var tgm = "[" + targetName + " -> 나]" + message;
                    sender.SendMessage(senderm);
                    targetPlayer.SendMessage(tgm);
                }
                else
                {
                    var senderm = "[나 -> " + targetName + "]" + message;
                    var tgm = "[" + targetName + " -> 나]" + message;
                    sender.SendMessage(senderm);
                    targetPlayer.SendMessage(tgm);
                    sender.SendMessage("[Essentials]상대방이 잠수 상태이므로 응답하지 않을 수 있습니다!");
                }
            }
        }
    }
}
