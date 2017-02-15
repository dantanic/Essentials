
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
using System.Collections.Generic;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiOP;

namespace Essentials.Command
{
    public class TpCommand
    {
        private Essentials Plugin { get; set; }
        public TpCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }

        List<string> tpalist = new List<string>();
        
        [Command(Description = "Op만 사용가능")]
        public void tp(Player sender, string targetname)
        {
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }
            if (targetPlayer == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            } else
            {
                sender.Teleport(new PlayerLocation()
                {
                    X = targetPlayer.KnownPosition.X,
                    Y = targetPlayer.KnownPosition.Y,
                    Z = targetPlayer.KnownPosition.Z
                });
            }
        }
        [Command(Description = "Op만 사용가능")]
        public void tp(Player sender, string targetonen, string targettwon)
        {
            var ServerPlayers = sender.Level.Players;
            var targetone = ServerPlayers.ToList().Find(x => x.Value.Username == targetonen).Value;
            var targettwo = ServerPlayers.ToList().Find(x => x.Value.Username == targettwon).Value;
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }
            if (targetone == null || targettwo == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            }
            else
            {
                targetone.Teleport(new PlayerLocation()
                {
                    X = targettwo.KnownPosition.X,
                    Y = targettwo.KnownPosition.Y,
                    Z = targettwo.KnownPosition.Z
                });
                sender.SendMessage("[Essentials] " + targetonen + "님을 " + targettwon + "님에게 티피시켰습니다.");
                targetone.SendMessage("[Essentials] 관리자 " + sender.Username + "님이 당신을 " + targettwon + "님에게 티피시켰습니다.");
                targettwo.SendMessage("[Essentials] 관리자 " + sender.Username + "님이 " + targetonen + "님을 당신에게 티피시켰습니다.");
            }
        }
        [Command]
        public void tpa(Player sender, string targetname)
        {
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (target == null)
            {
                sender.SendMessage("플레이어가 존재하지 않습니다!");
            } else
            {
                tpalist.Add(sender.Username + "," + targetname);
                sender.SendMessage(targetname + "님에게 텔레포트 요청을 하였습니다");
                target.SendMessage(sender.Username + "님께서 당신에게 텔레포트 요청을 하였습니다.");
                target.SendMessage("수락하시려면 tpaccept,");
                target.SendMessage("거절하시려면 tpdeny");
                target.SendMessage("명령어를 입력해주세요.");
            }
        }
        [Command]
        public void tpaccept(Player sender)
        {
            foreach(var item in tpalist)
            {
                string[] pitem = item.Split(',');
                if(pitem[1] == sender.Username)
                {
                    var ServerPlayers = sender.Level.Players;
                    var target = ServerPlayers.ToList().Find(x => x.Value.Username == pitem[0]).Value;
                    sender.SendMessage("텔레포트 요청을 수락하였습니다.");
                    target.SendMessage(sender.Username + "님이 텔레포트 요청을 수락하셨습니다.");
                    target.Teleport(new PlayerLocation()
                    {
                        X = sender.KnownPosition.X,
                        Y = sender.KnownPosition.Y,
                        Z = sender.KnownPosition.Z
                    });
                    tpalist.Remove(item);
                } else
                {
                    sender.SendMessage("보류중인 텔레포트 요청이 없습니다.");
                }
            }
        }
        [Command]
        public void tpdeny(Player sender)
        {
            foreach (var item in tpalist)
            {
                string[] pitem = item.Split(',');
                if (pitem[1] == sender.Username)
                {
                    var ServerPlayers = sender.Level.Players;
                    var target = ServerPlayers.ToList().Find(x => x.Value.Username == pitem[0]).Value;
                    sender.SendMessage("텔레포트 요청을 거절하였습니다.");
                    target.SendMessage(sender.Username + "님이 텔레포트 요청을 거절하셨습니다.");
                    tpalist.Remove(item);
                }
                else
                {
                    sender.SendMessage("보류중인 텔레포트 요청이 없습니다.");
                }
            }
        }
    }
}
