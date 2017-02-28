
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

namespace Essentials.Command
{
    public class Heal
    {
        private Essentials Plugin;

        public Heal(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "heal", Description = "Heal your health or other player.")]
        public void Execute(Player sender, int amount)
        {
            HealthManager healthmanager = new HealthManager(sender);

            healthmanager.Health = healthmanager.Health + amount;

            sender.SendMessage(ChatColors.Green + "Healed.");
        }

        [Command(Name = "heal", Description = "Heal your health or other player.")]
        public void Execute(Player sender, string player, int amount)
        {
            if(Plugin.GetPlayer(player, sender.Level) != null)
            {
                HealthManager healthmanager = new HealthManager(Plugin.GetPlayer(player, sender.Level));

                healthmanager.Health = healthmanager.Health + amount;

                sender.SendMessage(ChatColors.Green + "Healed.");
            }
        }
    }
}