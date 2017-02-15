/*
     ________  ___  _______   ________     
    |\   __  \|\  \|\  ___ \ |\   __  \    
    \ \  \|\  \ \  \ \   __/|\ \  \|\  \   
     \ \   ____\ \  \ \  \_|/_\ \   __  \  
      \ \  \___|\ \  \ \  \_|\ \ \  \ \  \ 
       \ \__\    \ \__\ \_______\ \__\ \__\
        \|__|     \|__|\|_______|\|__|\|__|          
    
    PIEA, The MiNET plugins development organization.                  
    ⓒ Copyright 2017 PIEA.  All Right Reserved                         
*/

using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiNET.Worlds;
using MiOP;
using System;
using System.Linq;

namespace Essentials.Command
{
    public class GamemodeCommand
    {
        private Essentials Plugin { get; set; }

        public GamemodeCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }

        [Command(Description = "게임모드를 변경합니다. OP만 이용가능합니다.")]
        public void Gamemode(Player sender)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender))
            {
                return;
            }

            sender.SendMessage($"{ChatColors.Green}/gamemode [gamemode number] -> 게임모드를 변경합니다.");
            sender.SendMessage($"{ChatColors.Green}/gamemode [gamemode number] [target name] -> 상대방의 게임모드를 변경합니다.");
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
                sender.SendMessage($"{ChatColors.Green}게임모드를 {gameModeSet.ToString()}로 변경하였습니다.");
            }
            else
            {
                sender.SendMessage($"{ChatColors.Yellow}일치하는 게임모드의 값이 없습니다!");
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
                sender.SendMessage($"{ChatColors.Yellow}일치하는 플레이어가 없습니다.");
                return;
            }

            if (Enum.IsDefined(typeof(GameMode), gamemodeValue))
            {
                var gameModeSet = (GameMode)gamemodeValue;
                targetPlayer.SetGameMode(gameModeSet);
                targetPlayer.SendMessage($"{ChatColors.Green}{sender.Username}님이 당신의 게임모드를 {gameModeSet.ToString()}로 변경하였습니다.");
                sender.SendMessage($"{ChatColors.Green}{targetPlayer.Username}님의 게임모드를 {gameModeSet.ToString()}로 변경하였습니다.");
            }
            else
            {
                sender.SendMessage($"{ChatColors.Yellow}일치하는 게임모드의 값이 없습니다!");
            }
        }
    }
}
