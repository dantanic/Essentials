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

using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiNET.Worlds;
using MiOP;
using System;
using System.Linq;
using Essentials.Resources;

namespace Essentials.Command
{
    public class GamemodeCommand
    {
        private Essentials Plugin { get; set; }

        public GamemodeCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }

        [Command]
        public void Gamemode(Player sender)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }

            sender.SendMessage($"{ChatColors.Green}/gamemode [gamemode number] -> " + StringResources.Gamemode_Help1);
            sender.SendMessage($"{ChatColors.Green}/gamemode [gamemode number] [target name] -> " + StringResources.Gamemode_Help2);
        }

        [Command]
        public void Gamemode(Player sender, int gamemodeValue)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }

            if (Enum.IsDefined(typeof(GameMode), gamemodeValue))
            {
                var gameModeSet = (GameMode)gamemodeValue;
                sender.SetGameMode(gameModeSet);
                sender.SendMessage($"{ChatColors.Green}{StringResources.Gamemode_DisplayCompletedResult.Replace("{{value}}", gameModeSet.ToString())}");
            }
            else
            {
                sender.SendMessage($"{ChatColors.Yellow}{StringResources.Gamemode_InvaildGameModeValue.Replace("{{value}}", gamemodeValue.ToString())}");
            }
        }

        [Command]
        public void Gamemode(Player sender, int gamemodeValue, string targetName)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }

            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage($"{ChatColors.Yellow}{StringResources.Gamemode_PlayerNotFound}");
                return;
            }

            if (Enum.IsDefined(typeof(GameMode), gamemodeValue))
            {
                var gameModeSet = (GameMode)gamemodeValue;
                targetPlayer.SetGameMode(gameModeSet);

                var msg_player = StringResources.Gamemode_DisplayCompletedResult_Target.Replace("{{target}}", targetPlayer.Username);
                msg_player = msg_player.Replace("{{gamemode}}", gameModeSet.ToString());
                sender.SendMessage(ChatColors.Green + msg_player);
            }
            else
            {
                sender.SendMessage(ChatColors.Yellow + StringResources.Gamemode_PlayerNotFound);
            }
        }
        [Command]
        public void gm(Player sender)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }

            sender.SendMessage($"{ChatColors.Green}/gm [gamemode number] -> " + StringResources.Gamemode_Help1);
            sender.SendMessage($"{ChatColors.Green}/gm [gamemode number] [target name] -> " + StringResources.Gamemode_Help2);
        }

        [Command]
        public void gm(Player sender, int gamemodeValue)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }

            if (Enum.IsDefined(typeof(GameMode), gamemodeValue))
            {
                var gameModeSet = (GameMode)gamemodeValue;
                sender.SetGameMode(gameModeSet);
                sender.SendMessage($"{ChatColors.Green}{StringResources.Gamemode_DisplayCompletedResult.Replace("{{value}}", gameModeSet.ToString())}");
            }
            else
            {
                sender.SendMessage($"{ChatColors.Yellow}{StringResources.Gamemode_InvaildGameModeValue.Replace("{{value}}", gamemodeValue.ToString())}");
            }
        }

        [Command]
        public void gm(Player sender, int gamemodeValue, string targetName)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }

            var ServerPlayers = sender.Level.Players;
            var targetPlayer = ServerPlayers.ToList().Find(x => x.Value.Username == targetName).Value;
            if (targetPlayer == null)
            {
                sender.SendMessage($"{ChatColors.Yellow}{StringResources.Gamemode_PlayerNotFound}");
                return;
            }

            if (Enum.IsDefined(typeof(GameMode), gamemodeValue))
            {
                var gameModeSet = (GameMode)gamemodeValue;
                targetPlayer.SetGameMode(gameModeSet);

                var msg_player = StringResources.Gamemode_DisplayCompletedResult_Target.Replace("{{target}}", targetPlayer.Username);
                msg_player = msg_player.Replace("{{gamemode}}", gameModeSet.ToString());
                sender.SendMessage(ChatColors.Green + msg_player);
            }
            else
            {
                sender.SendMessage(ChatColors.Yellow + StringResources.Gamemode_PlayerNotFound);
            }
        }
    }
}
