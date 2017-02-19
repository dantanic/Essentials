
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
using Essentials.Resources;

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
        
        [Command]
        public void tp(Player sender, string targetname)
        {
            Essentials.permission(sender, "tp");
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_NoMatch}");
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
        [Command]
        public void tp(Player sender, string targetonen, string targettwon)
        {
            Essentials.permission(sender, "tp");
            var ServerPlayers = sender.Level.Players;
            var targetone = ServerPlayers.ToList().Find(x => x.Value.Username == targetonen).Value;
            var targettwo = ServerPlayers.ToList().Find(x => x.Value.Username == targettwon).Value;
            if (targetone == null || targettwo == null)
            {
                sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_NoMatch}");
            }
            else
            {
                targetone.Teleport(new PlayerLocation()
                {
                    X = targettwo.KnownPosition.X,
                    Y = targettwo.KnownPosition.Y,
                    Z = targettwo.KnownPosition.Z
                });
                sender.SendMessage($"{ChatColors.Gold}{targetonen} {StringResources.Tp_SenderMsg1.Replace("{{target}}", targettwon)}");
                targetone.SendMessage($"{ChatColors.Gold}{sender.Username} {StringResources.Tp_TargetMsg1.Replace("{{target}}", targettwon)}");
                targettwo.SendMessage($"{ChatColors.Gold}{sender.Username} {StringResources.Tp_TargetMsg2.Replace("{{target}}", targetonen)}");
            }
        }
        [Command]
        public void tp(Player sender, int tx, int ty, int tz)
        {
            Essentials.permission(sender, "tp");
            sender.Teleport(new PlayerLocation()
            {
                X = tx,
                Y = ty,
                Z = tz
            });
        }
        [Command]
        public void tp(Player sender, string targetname, int tx, int ty, int tz)
        {
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            Essentials.permission(sender, "tp");
            if (target == null)
            {
                sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_NoMatch}");
            } else
            {
                target.Teleport(new PlayerLocation()
                {
                    X = tx,
                    Y = ty,
                    Z = tz
                });
                var xyz = $"X:{tx}, Y:{ty}, Z:{tz}";
                sender.SendMessage($"{ChatColors.Red}{targetname} {StringResources.Tp_XYZMsg.Replace("{{xyz}}", xyz)}.");
                target.SendMessage($"{ChatColors.Red}{sender.Username} {StringResources.Tp_XYZMsg2.Replace("{{xyz}}", xyz)}.");
            }  
        }
        [Command]
        public void tpa(Player sender, string targetname)
        {
            Essentials.permission(sender, "tpa");
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (target == null)
            {
                sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_NoMatch}");
            } else
            {
                var color = ChatColors.Red;
                tpalist.Add(sender.Username + "," + targetname);
                sender.SendMessage($"{ChatColors.Gold}{StringResources.Tp_S1.Replace("{{target}}", targetname)}");
                target.SendMessage($"{ChatColors.Gold}{StringResources.Tp_T1.Replace("{{sender}}", sender.Username)}");
                target.SendMessage($"{ChatColors.Gold}{StringResources.Tp_T2.Replace("{{color}}", color)}{ChatColors.Gold},");
                target.SendMessage($"{ChatColors.Gold}{StringResources.Tp_T3.Replace("{{color}}", color)}");
                target.SendMessage($"{ChatColors.Gold}{StringResources.Tp_T4}");
            }
        }
        [Command]
        public void tpaccept(Player sender)
        {
            Essentials.permission(sender, "tpaccept");
            foreach (var item in tpalist)
            {
                string[] pitem = item.Split(',');
                if(pitem[1] == sender.Username)
                {
                    var ServerPlayers = sender.Level.Players;
                    var target = ServerPlayers.ToList().Find(x => x.Value.Username == pitem[0]).Value;
                    sender.SendMessage($"{ChatColors.Gold}{StringResources.Tp_A1}");
                    target.SendMessage($"{ChatColors.Gold}{StringResources.Tp_A2.Replace("{{sender}}", sender.Username)}");
                    target.Teleport(new PlayerLocation()
                    {
                        X = sender.KnownPosition.X,
                        Y = sender.KnownPosition.Y,
                        Z = sender.KnownPosition.Z
                    });
                    tpalist.Remove(item);
                    return;
                } else
                {
                    sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_P}");
                    return;
                }
            }
            sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_P}");
        }
        [Command]
        public void tpdeny(Player sender)
        {
            Essentials.permission(sender, "tpdeny");
            foreach (var item in tpalist)
            {
                string[] pitem = item.Split(',');
                if (pitem[1] == sender.Username)
                {
                    var ServerPlayers = sender.Level.Players;
                    var target = ServerPlayers.ToList().Find(x => x.Value.Username == pitem[0]).Value;
                    sender.SendMessage($"{ChatColors.Gold}{StringResources.Tp_D1}");
                    target.SendMessage($"{ChatColors.Gold}{StringResources.Tp_D2.Replace("{{sender}}", sender.Username)}");
                    tpalist.Remove(item);
                    return;
                }
                else
                {
                    sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_P}");
                    return;
                }
            }
            sender.SendMessage($"{ChatColors.Red}{StringResources.Tp_P}");
        }
    }
}
