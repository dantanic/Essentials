
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
    public class Bomb
    {
        private Essentials Plugin;

        public Bomb(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "bomb", Description = "Explode other player.")]
        public void Execute(Player sender)
        {
            PlayerLocation pos = sender.KnownPosition;

            Explosion explosion = new Explosion(sender.Level, new BlockCoordinates(pos), 5);
            explosion.Explode();

            sender.SendMessage(ChatColors.Red + "Bomb!");
        }

        [Command(Name = "bomb", Description = "Explode other player.")]
        public void Execute(Player sender, string player)
        {
            if(Plugin.GetPlayer(player) != null)
            {
                Player target = Plugin.GetPlayer(player);

                PlayerLocation pos = target.KnownPosition;

                Explosion explosion = new Explosion(sender.Level, new BlockCoordinates(pos), 5);
                explosion.Explode();

                sender.SendMessage(ChatColors.Red + "Bomb!");
            }
        }
    }
}
