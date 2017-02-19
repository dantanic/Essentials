
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
    public class HealCommand
    {
        private Essentials Plugin { get; set; }
        public HealCommand(Essentials plugin)
        {
            this.Plugin = plugin;
        }
        [Command]
        public void heal(Player sender)
        {
            Essentials.permission(sender, "heal");
            sender.HealthManager.Health = sender.HealthManager.MaxHealth;
            sender.HungerManager.Hunger = sender.HungerManager.MaxHunger;
        }
        [Command]
        public void heal(Player sender, string targetname)
        {
            Essentials.permission(sender, "heal");
            var ServerPlayers = sender.Level.Players;
            var target = ServerPlayers.ToList().Find(x => x.Value.Username == targetname).Value;
            target.HealthManager.Health = target.HealthManager.MaxHealth;
            target.HungerManager.Hunger = target.HungerManager.MaxHunger;
            sender.SendMessage($"{ChatColors.LightPurple}{StringResources.Heal_1.Replace("{{target}}", targetname)}");
            target.SendMessage($"{ChatColors.LightPurple}{StringResources.Heal_2.Replace("{{sender}}", sender.Username)}");
        }
    }
}