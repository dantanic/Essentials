
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
using Essentials.Util;

namespace Essentials.Command
{
    public class TpCommand : BaseCommand
    {
        List<string> tpalist = new List<string>();
        
        [Command]
        public void tp(Player sender, string targetname)
        {
            if (!VerifyPermission(sender, "tp"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_NoMatch}");
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
            if (!VerifyPermission(sender, "tp"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var targetone = ServerPlayers.ToList().Find(x => x.Value.Username == targetonen).Value;
            var targettwo = ServerPlayers.ToList().Find(x => x.Value.Username == targettwon).Value;
            if (targetone == null || targettwo == null)
            {
                sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_NoMatch}");
            }
            else
            {
                targetone.Teleport(new PlayerLocation()
                {
                    X = targettwo.KnownPosition.X,
                    Y = targettwo.KnownPosition.Y,
                    Z = targettwo.KnownPosition.Z
                });
                sender.SendMessage
                    ($"{ContextConstants.Prefix}{ChatColors.Gold}{targetonen} {StringResources.Tp_SenderMsg1.Replace("{{target}}", targettwon)}");
                targetone.SendMessage
                    ($"{ContextConstants.Prefix}{ChatColors.Gold}{sender.Username} {StringResources.Tp_TargetMsg1.Replace("{{target}}", targettwon)}");
                targettwo.SendMessage
                    ($"{ContextConstants.Prefix}{ChatColors.Gold}{sender.Username} {StringResources.Tp_TargetMsg2.Replace("{{target}}", targetonen)}");
            }
        }
        [Command]
        public void tp(Player sender, int tx, int ty, int tz)
        {
            if (!VerifyPermission(sender, "tp"))
            {
                return;
            }
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
            if (!VerifyPermission(sender, "tp"))
            {
                return;
            }

            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (target == null)
            {
                sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_NoMatch}");
            } else
            {
                target.Teleport(new PlayerLocation()
                {
                    X = tx,
                    Y = ty,
                    Z = tz
                });
                var xyz = $"X:{tx}, Y:{ty}, Z:{tz}";
                sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{targetname} {StringResources.Tp_XYZMsg.Replace("{{xyz}}", xyz)}.");
                target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{sender.Username} {StringResources.Tp_XYZMsg2.Replace("{{xyz}}", xyz)}.");
            }  
        }
        [Command]
        public void tpa(Player sender, string targetname)
        {
            if (!VerifyPermission(sender, "tpa"))
            {
                return;
            }
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            if (target == null)
            {
                sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_NoMatch}");
            } else
            {
                var color = ChatColors.Red;
                tpalist.Add(sender.Username + "," + targetname);
                sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_S1.Replace("{{target}}", targetname)}");
                target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_T1.Replace("{{sender}}", sender.Username)}");
                target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_T2.Replace("{{color}}", color)}{ChatColors.Gold},");
                target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_T3.Replace("{{color}}", color)}");
                target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_T4}");
            }
        }
        [Command]
        public void tpaccept(Player sender)
        {
            if (!VerifyPermission(sender, "tpaccept"))
            {
                return;
            }
            foreach (var item in tpalist)
            {
                string[] pitem = item.Split(',');
                if(pitem[1] == sender.Username)
                {
                    var ServerPlayers = sender.Level.Players;
                    var target = ServerPlayers.ToList().Find(x => x.Value.Username == pitem[0]).Value;
                    sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_A1}");
                    target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_A2.Replace("{{sender}}", sender.Username)}");
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
                    sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_P}");
                    return;
                }
            }
            sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_P}");
        }
        [Command]
        public void tpdeny(Player sender)
        {
            if (!VerifyPermission(sender, "tpdenny"))
            {
                return;
            }
            foreach (var item in tpalist)
            {
                string[] pitem = item.Split(',');
                if (pitem[1] == sender.Username)
                {
                    var ServerPlayers = sender.Level.Players;
                    var target = ServerPlayers.ToList().Find(x => x.Value.Username == pitem[0]).Value;
                    sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_D1}");
                    target.SendMessage($"{ContextConstants.Prefix}{ChatColors.Gold}{StringResources.Tp_D2.Replace("{{sender}}", sender.Username)}");
                    tpalist.Remove(item);
                    return;
                }
                else
                {
                    sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_P}");
                    return;
                }
            }
            sender.SendMessage($"{ContextConstants.Prefix}{ChatColors.Red}{StringResources.Tp_P}");
        }
    }
}
